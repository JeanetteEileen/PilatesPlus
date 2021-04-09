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
    public class ClientController : Controller
    {
        // GET: Client
        public ActionResult Index()
        {
            var service = CreateClientService();
            var model = service.GetClients();

            return View();
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

        // GET: helper method
        private ClientService CreateClientService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ClientService(userId);
            return service;
        }
        
    }
}