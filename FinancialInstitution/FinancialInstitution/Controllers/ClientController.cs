using DataAccessLayerCommon;

using DataAccessLayerCommon.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinancialInstitution.Mappers;

namespace FinancialInstitution.Controllers
{
    public class ClientController : Controller
    {
        private IClientRepository clientRepository { get; set; }
        private ClientMapper clientMapper { get; set; }

        public ClientController(IClientRepository clientRepository)
        {
            this.clientRepository = clientRepository;
            clientMapper = new ClientMapper();
        }
        public ActionResult ShowShort()
        {
            IEnumerable<Client> clients = clientRepository.GetAll();
            List<Models.Client> clientModels = new List<Models.Client>();
            foreach (Client c in clients)
            {
                Models.Client tempClient = clientMapper.MapFromEntity(c);
                clientModels.Add(tempClient);
            }
            return View(clientModels);
        }
        [HttpGet]
        public ActionResult ShowAll(int id)
        {
            Models.Client client = clientMapper.MapFromEntity(clientRepository.GetItem(id));
            return View(client);
        }


        [HttpGet]
        public ActionResult Delete(int id)
        {
            try
            {
                clientRepository.Delete(id);
                return Redirect("/client/showshort");

            }
            catch(Exception ex)
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
        public ActionResult Add(Models.Client client)
        {
            if (ModelState.IsValid)
            {
                DataAccessLayerCommon.Client Client = clientMapper.MapFromModel(client);
                clientRepository.Insert(Client);
                return RedirectPermanent("/client/showshort");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            DataAccessLayerCommon.Client clientFromCommon = clientRepository.GetItem(id);
            Models.Client client = clientMapper.MapFromEntity(clientFromCommon);
            return View(client);
        }

        [HttpPost]
        public ActionResult Edit(Models.Client client, int id)
        {
            if (ModelState.IsValid)
            {
                DataAccessLayerCommon.Client Client = clientMapper.MapFromModel(client);
                clientRepository.Update(id, Client);
                return RedirectPermanent("/client/showshort");
            }
            return View(client);
        }

    }
}