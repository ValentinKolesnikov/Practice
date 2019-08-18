using DataAccessLayerCommon.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FinancialInstitution.Mappers;
using DataAccessLayerCommon;
using System.Web.Mvc;
using DataAccessLayerEF.Repositories;
using System.Collections;

namespace FinancialInstitution.Controllers
{
    public class ServicesHistoryController : Controller
    {
        private ServiceHistoryRepository servicesHistoryRepository { get; set; }
        private ServicesHistoryMapper serviceHistoryMapper { get; set; }
        private IClientRepository clientRepository { get; set; }
        private ClientMapper clientMapper { get; set; }
        private IServicesHistoryRepository serviceHistoryRepository { get; set; }
        private IBranchRepository branchRepository { get; set; }
        private IEmployeeRepository employeeRepository { get; set; }
        private IServicesDirectoryRepository servicesDirectoryRepository { get; set; }

        public ServicesHistoryController(IServicesHistoryRepository servicesHistoryRepository)
        {
            this.servicesHistoryRepository = new ServiceHistoryRepository();
            this.serviceHistoryMapper = new ServicesHistoryMapper();
            clientRepository = new ClientRepository();
            clientMapper = new ClientMapper();
            serviceHistoryRepository = new ServiceHistoryRepository();
            branchRepository = new BranchRepository();
            employeeRepository = new EmployeeRepository();
            servicesDirectoryRepository = new ServiceDirectoryRepository();
        }

        [HttpGet]
        public ActionResult Show(int id)
        {
            Client client = clientRepository.GetItem(id);

            IEnumerable<ServicesHistory> servicesHistories = servicesHistoryRepository.GetHistories(id);
            List<Models.ServicesHistoryShow> servicesHistoryModels = new List<Models.ServicesHistoryShow>();
            TempData["CurrentClientId"] = id;
            TempData["FullName"] = $"{client.SecondName} {client.FirstName} {client.MiddleName}";
            foreach (ServicesHistory c in servicesHistories)
            {
                servicesHistoryModels.Add(serviceHistoryMapper.MapFromEntityShow(c));
            }
            return View(servicesHistoryModels);
        }

        [HttpPost]
        public ActionResult GetInfo(HttpPostAttribute post)
        {
            Console.WriteLine(Request.Params["id"]);
            int id = Convert.ToInt32(Request.Params["id"]);

            //var jsondata = employeeRepository.GetList().Where(e => e.BranchId == id);


            ArrayList list = new ArrayList();
            list.Add(employeeRepository.GetList().Where(e => e.BranchId == id));
            list.Add(servicesDirectoryRepository.GetAll());

            return Json(list, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            try
            {
                servicesHistoryRepository.Delete(id);
                return RedirectPermanent(this.Request.UrlReferrer.AbsolutePath);
                
            }
            catch (Exception ex)
            {
                return RedirectPermanent("/error/showerror");

            }

        }
        [HttpGet]
        public ActionResult Add(int id)
        {
            Client client = clientRepository.GetItem(id);
            Models.ServicesHistoryEdit she = new Models.ServicesHistoryEdit();
            she.FirstName = client.FirstName;
            she.SecondName = client.SecondName;
            she.MiddleName = client.MiddleName;
            she.ClientId = client.Id;

            ViewBag.branches = new SelectList(branchRepository.GetList(), "Id", "Name");
            ViewBag.employees = new SelectList(employeeRepository.GetList(), "Id", "SecondName");
            ViewBag.serviceDirectories = new SelectList(servicesDirectoryRepository.GetAll(), "Id", "Name");

            return View(she);
        }

        [HttpPost]
        public ActionResult Add(int id, Models.ServicesHistoryEdit servicesHistory)
        {

            ViewBag.branches = new SelectList(branchRepository.GetList(), "Id", "Name");
            ViewBag.employees = new SelectList(employeeRepository.GetList(), "Id", "SecondName");
            ViewBag.serviceDirectories = new SelectList(servicesDirectoryRepository.GetAll(), "Id", "Name");

            Client client = clientRepository.GetItem(id);
            servicesHistory.FirstName = client.FirstName;
            servicesHistory.SecondName = client.SecondName;
            servicesHistory.MiddleName = client.MiddleName;
            servicesHistory.ClientId = client.Id;

            if (ModelState.IsValid)
            {
                DataAccessLayerCommon.ServicesHistory sh = serviceHistoryMapper.MapFromModelEdit(servicesHistory);
                sh.Date = DateTime.Now;
                servicesHistoryRepository.Insert(sh);
                return RedirectPermanent("/ServicesHistory/show/" + id);
            }


            return View(servicesHistory);

        }

        [HttpGet]
        public ActionResult Edit(int id)
        {

            ViewBag.branches = new SelectList(branchRepository.GetList(), "Id", "Name");
            DataAccessLayerCommon.ServicesHistory sh = serviceHistoryRepository.GetItem(id);

            
            ViewBag.serviceDirectories = new SelectList(servicesDirectoryRepository.GetAll(), "Id", "Name");

            Models.ServicesHistoryEdit servicesHistoryModel = serviceHistoryMapper.MapFromEntityEdit(serviceHistoryRepository.GetItem(id));
            Client c = clientRepository.GetItem(servicesHistoryModel.ClientId);
            servicesHistoryModel.FirstName = c.FirstName;
            servicesHistoryModel.SecondName = c.SecondName;
            servicesHistoryModel.MiddleName = c.MiddleName;
            servicesHistoryModel.Id = id;
            TempData["ClientId"] = c.Id;

            ViewBag.BranchName = branchRepository.GetItem(servicesHistoryModel.BranchId).Name;
            Employee emp = employeeRepository.GetItem(servicesHistoryModel.EmployeeId);
            ViewBag.employees = new SelectList(employeeRepository.GetList().Where(e => e.BranchId ==emp.BranchId), "Id", "SecondName");
            ViewBag.EmployeeName = $"{emp.SecondName} {emp.FirstName[0]}. {emp.MiddleName[0]}.";
            ViewBag.ServiceName = servicesDirectoryRepository.GetItem(servicesHistoryModel.ServicesDirectoryId).Name;
            return View(servicesHistoryModel);
        }

        [HttpPost]
        public ActionResult Edit(Models.ServicesHistoryEdit servicesHistory, int id)
        {

            ViewBag.branches = new SelectList(branchRepository.GetList(), "Id", "Name");
            ViewBag.employees = new SelectList(employeeRepository.GetList(), "Id", "SecondName");
            ViewBag.serviceDirectories = new SelectList(servicesDirectoryRepository.GetAll(), "Id", "Name");
            servicesHistory.ClientId = serviceHistoryRepository.GetItem(id).ClientId;
            servicesHistory.Id = id;

            if (ModelState.IsValid)
            {
                DataAccessLayerCommon.ServicesHistory sh = serviceHistoryMapper.MapFromModelEdit(servicesHistory);
                sh.Date = DateTime.Now;
                servicesHistoryRepository.Update(id, sh);
                return RedirectPermanent("/ServicesHistory/show/" + servicesHistory.ClientId);
            }
            return View(servicesHistory);
        }

    }
}