using DataAccessLayerCommon.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinancialInstitution.Mappers;
namespace FinancialInstitution.Controllers
{
    public class BranchController : Controller
    {
        private IBranchRepository branchRepository { get; set; }
        private BranchMapper branchMapper { get; set; }

        public BranchController(IBranchRepository branchRepository)
        {
            this.branchRepository = branchRepository;
            branchMapper = new BranchMapper();
        }


        public ActionResult ShowAll()
        {
            IEnumerable<DataAccessLayerCommon.Branch> branches = branchRepository.GetList();
            List<Models.Branch> branchModels = new List<Models.Branch>();
            foreach (DataAccessLayerCommon.Branch b in branches)
            {
                Models.Branch tempBranch = branchMapper.MapFromEntity(b);
                branchModels.Add(tempBranch);
            }
            return View(branchModels);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            try
            {
                branchRepository.Delete(id);
                return RedirectPermanent("/branch/showall");
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
        public ActionResult Add(Models.Branch branch)
        {
            if (ModelState.IsValid)
            {
                DataAccessLayerCommon.Branch Branch = branchMapper.MapFromModel(branch);
                branchRepository.Insert(Branch);
                return RedirectPermanent("/branch/showall");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            DataAccessLayerCommon.Branch branchFromCommon = branchRepository.GetItem(id);
            Models.Branch branch = branchMapper.MapFromEntity(branchFromCommon);
            return View(branch);
        }

        [HttpPost]
        public ActionResult Edit(Models.Branch branch, int id)
        {
            if (ModelState.IsValid)
            {
                DataAccessLayerCommon.Branch Branch = branchMapper.MapFromModel(branch);
                branchRepository.Update(id, Branch);
                return RedirectPermanent("/branch/showall");
            }
            return View(branch);
        }

    }
}