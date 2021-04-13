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
            //var model = new ClientListItem[0];
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
                TempData["SaveResult"] = "Your client was created.";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "Your client could not be created.");
            return View(model);
        }
        // GET: Details
        public ActionResult Details(int id)
        {
            var svc = CreateClientService();
            var model = svc.GetClientById(id);

            return View(model);
        }
        // GET: Edit
        public ActionResult Edit(int id, ClientEdit model)
        {
            if (!ModelState.IsValid) return View(model);
            return View(model);

            if(model.ClientId != id)
            {
                ModelState.AddModelError("", "Given Id and model Id are not matched");
                return View(model);
            }
            var service = CreateClientService();
            if (service.UpdateClient(model))
            {
                TempData["SaveResult"] = "Your client information was updated.";
                return RedirectToAction("Index");
            }
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