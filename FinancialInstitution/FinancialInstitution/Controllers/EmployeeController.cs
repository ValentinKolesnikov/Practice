using DataAccessLayerCommon.Interfaces;
using System.Collections.Generic;
using DataAccessLayerCommon;
using FinancialInstitution.Mappers;
using System.Web.Mvc;
using System;

namespace FinancialInstitution.Controllers
{
    public class EmployeeController : Controller
    {
        private IEmployeeRepository employeeRepository { get; set; }
        private IBranchRepository branchRepository { get; set; }
        private IPositionRepository positionRepository { get; set; }
        private EmployeeMapper employeeMapper { get; set; }



        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = new DataAccessLayerEF.Repositories.EmployeeRepository();
            this.branchRepository = new DataAccessLayerEF.Repositories.BranchRepository();
            this.positionRepository = new DataAccessLayerEF.Repositories.PositionRepository();
            employeeMapper = new EmployeeMapper();
        }


        public ActionResult ShowOne(int id)
        {
            Employee f = employeeRepository.GetItemWithBranchAndPosition(id);
            return View(employeeMapper.MapFromItem(f));
        }


        public ActionResult Show()
        {
            IEnumerable<Employee> f = employeeRepository.GetListWithBranchAndPosition();
            return View(employeeMapper.MapFromList(f));
        }

        [HttpGet]
        public RedirectResult Delete(int id)
        {
            employeeRepository.Delete(id);
            return RedirectPermanent("/employee/show");
        }

        [HttpGet]
        public ActionResult Add()
        {
            ViewBag.branches = new SelectList(branchRepository.GetList(), "Id", "Name");
            ViewBag.positions = new SelectList(positionRepository.GetList(), "Id", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult Add(Models.Employee employee)
        {
            ViewBag.branches = new SelectList(branchRepository.GetList(), "Id", "Name");
            ViewBag.positions = new SelectList(positionRepository.GetList(), "Id", "Name");
            if (!ModelState.IsValid)
                return View();

            employeeRepository.Insert(employeeMapper.MapToItem(employee));
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewBag.branches = new SelectList(branchRepository.GetList() ,"Id", "Name");
            ViewBag.positions = new SelectList(positionRepository.GetList(), "Id", "Name");
            return View(employeeMapper.MapFromItem(employeeRepository.GetItemWithBranchAndPosition(id)));
        }

        [HttpPost]
        public ActionResult Edit(Models.Employee employee, int id)
        {
            ViewBag.branches = new SelectList(branchRepository.GetList(), "Id", "Name");
            ViewBag.positions = new SelectList(positionRepository.GetList(), "Id", "Name");
            if (!ModelState.IsValid)
                return View(employee);

            employeeRepository.Update(id, employeeMapper.MapToItem(employee));
            return RedirectPermanent("/employee/show");
        }
    }
}