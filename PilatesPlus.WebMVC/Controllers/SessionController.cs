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
        public ActionResult Details(int id)
        {
            var svc = CreateSessionService();
            var model = svc.GetSessionById(id);

            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var service = CreateSessionService();
            var detail = service.GetSessionById(id);
            var model =
                new SessionEdit
                {
                    SessionId = detail.SessionId,
                    ClientId = detail.ClientId,
                    FirstName = detail.FirstName,
                    LastName = detail.LastName,
                    SessionDate = detail.SessionDate,
                    SessionNote = detail.SessionNote,
                    IsDuet = detail.IsDuet
                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, SessionEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.SessionId != id)
            {
                ModelState.AddModelError("", "Id's mismatched");
                return View(model);
            }
            var service = CreateSessionService();
            if (service.UpdateSession(model))
            {
                TempData["SaveResult"] = "Your Session was updated.";
                return RedirectToAction("Index");
            }
            return View();
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