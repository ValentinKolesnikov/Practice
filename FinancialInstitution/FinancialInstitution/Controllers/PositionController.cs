using DataAccessLayerCommon.Interfaces;
using DataAccessLayerCommon;
using FinancialInstitution.Mappers;
using System.Web.Mvc;
using System;

namespace FinancialInstitution.Controllers
{
    public class PositionController : Controller
    {
        private IPositionRepository positionRepository { get; set; }
        private Mappers.PositionMapper positionMapper;

        public PositionController(IPositionRepository positionRepository)
        {
            this.positionRepository = positionRepository;
            positionMapper = new PositionMapper();
        }

        public ActionResult Show()
        {
            return View(positionMapper.MapFromList(positionRepository.GetList()));
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            try
            {
                positionRepository.Delete(id);
                return RedirectPermanent("/position/show");
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
        public ActionResult Add(Models.Position position)
        {
            if (!ModelState.IsValid)
                return View();

            positionRepository.Insert(positionMapper.MapToItem(position));
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(positionMapper.MapFromItem(positionRepository.GetItem(id)));
        }

        [HttpPost]
        public ActionResult Edit(Models.Position position, int id)
        {
            if (!ModelState.IsValid)
                return View(position);

            positionRepository.Update(id, positionMapper.MapToItem(position));
            return RedirectPermanent("/position/show");
        }
    }
}