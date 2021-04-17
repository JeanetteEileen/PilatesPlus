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
    public class EquipmentController : Controller
    {
        // GET: Equipment
        public ActionResult Index()
        {
            var service = CreateEquipmentService();
            var model = service.GetEquipments();
            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EquipmentCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateEquipmentService();
            
            if (service.CreateEquipment(model))
            {
                TempData["SaveResult"] = "Your Equipment was created.";
                return RedirectToAction("Index");                
            };
            ModelState.AddModelError("", "Your Equipment could not be created. Please review your inputs.");
            return View(model);
        }
        public ActionResult Details(int id)
        {
            var svc = CreateEquipmentService();
            var model = svc.GetEquipmentById(id);

            return View(model);
        }

        private EquipmentService CreateEquipmentService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new EquipmentService(userId);
            return service;

        }
    }
}