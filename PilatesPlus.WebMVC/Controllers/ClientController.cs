using Microsoft.AspNet.Identity;
using PilatesPlus.Models;
using PilatesPlus.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PilatesPlus.WebMVC.Controllers
{
    [Authorize]
    public class ClientController : Controller
    {
        // GET: Client
        public ActionResult Index()
        {
            var service = CreateClientService();
            var model = service.GetClients();

            return View(model);
        }
       
        // GET: Create
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClientCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateClientService();
            
            if (service.CreateClient(model))
            {
                TempData["SaveResult"] = "Your Client was created.";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "Your Client could not be created.");
            return View(model);
        }
        // GET: Details
        public ActionResult Details(int id)
        {
            var svc = CreateClientService();
            var model = svc.GetClientById(id);

            TempData["clientInfo"] = model.ToString();

            return View(model);
        }
        [Route("ClientSessions")]
        public ActionResult ClientSessions(int id)
        {
            var svc = CreateClientService();
            var model = svc.GetSessionsByClientId(id);
            return View(model);

        }
        public ActionResult CSEquipmentDetails(int id)
        {
            var svc = CreateClientService();
            var model = svc.GetSessionEquipmentByClientId(id);
            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var service = CreateClientService();
            var detail = service.GetClientById(id);
            var model =
                new ClientEdit
                {
                    ClientId = detail.ClientId,
                    FirstName = detail.FirstName,
                    LastName = detail.LastName,
                    Email = detail.Email,
                    CellPhone = detail.CellPhone,
                    ClientActive = detail.ClientActive
                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ClientEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.ClientId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateClientService();

            if (service.UpdateClient(model))
            {
                TempData["SaveResult"] = "Your Client was updated.";
                return RedirectToAction("Index");
            }
            return View();
        }


        // GET: helper method
        private ClientService CreateClientService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ClientService(userId);
            return service;
        }
        
    }
}