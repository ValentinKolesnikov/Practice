using DataAccessLayerCommon.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FinancialInstitution.Mappers;
using DataAccessLayerCommon;
using System.Web.Mvc;

namespace FinancialInstitution.Controllers
{
    public class ServicesDirectoryController : Controller
    {
        private IServicesDirectoryRepository servicesDirectoryRepository { get; set; }
        private ServicesDirectoryMapper serviceDirectoryMapper { get; set; }


        public ServicesDirectoryController(IServicesDirectoryRepository servicesDirectoryRepository)
        {
            this.servicesDirectoryRepository = servicesDirectoryRepository;
            this.serviceDirectoryMapper = new ServicesDirectoryMapper();
        }
        public ActionResult Show()
        {
            IEnumerable<ServicesDirectory> servicesDirectories = servicesDirectoryRepository.GetAll();
            List<Models.ServicesDirectory> servicesDirectoryModels = new List<Models.ServicesDirectory>();
            foreach (ServicesDirectory c in servicesDirectories)
            {
                servicesDirectoryModels.Add(serviceDirectoryMapper.MapFromEntity(c));
            }
            return View(servicesDirectoryModels);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            try
            {
                servicesDirectoryRepository.Delete(id);
                return RedirectPermanent("/ServicesDirectory/show/");
            }
            catch (Exception ex)
            {
                return RedirectPermanent("/error/showerror");

            }

        }
            
    [HttpGet]
    public ActionResult Add()
    {
        return View();
    }

    [HttpPost]
    public ActionResult Add(Models.ServicesDirectory servicesDirectory)
    {
        if (ModelState.IsValid)
        {
            servicesDirectoryRepository.Insert(serviceDirectoryMapper.MapFromModel(servicesDirectory));
            return RedirectPermanent("/ServicesDirectory/show/");
        }
        return View();
    }

    [HttpGet]
    public ActionResult Edit(int id)
    {
        Models.ServicesDirectory serviceDirectoryModel = serviceDirectoryMapper.MapFromEntity(servicesDirectoryRepository.GetItem(id));

        return View(serviceDirectoryModel);
    }

    [HttpPost]
    public ActionResult Edit(Models.ServicesDirectory servicesDirectory, int id)
    {

        if (ModelState.IsValid)
        {
            servicesDirectoryRepository.Update(id, serviceDirectoryMapper.MapFromModel(servicesDirectory));
            return RedirectPermanent("/ServicesDirectory/show");
        }
        servicesDirectory.Id = id;
        return View(servicesDirectory);
    }

}
}
