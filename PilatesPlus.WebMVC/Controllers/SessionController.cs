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
    public class SessionController : Controller
    {
        // GET: Session
        public ActionResult Index()
        {
            var service = CreateSessionService();
            var model = service.GetSessions();
            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SessionCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateSessionService();

            if (service.CreateSession(model))
            {
                TempData["SaveResult"] = "Your Session was created";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "Your Session could not be created. Please review your entries.");
            return View(model);
        }

        // GET: helper method
        private SessionService CreateSessionService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new SessionService(userId);
            return service;
        }
    }
}