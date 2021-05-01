using Microsoft.AspNet.Identity;
using PilatesPlus.Data;
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

            ViewBag.TotalSessions = model.ToList().Count;

            return View(model);
        }//GET: Session Create
        public ActionResult Create()
        {
            
            var service = CreateSessionService();

            List<Client> clients = service.GetClientList().ToList();

            var query = from c in clients
                        select new SelectListItem()
                        {
                            Value = c.ClientId.ToString(),
                            Text = c.LastName + " " + c.FirstName
                        };
            ViewBag.ClientId = query;
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

            var userId = Guid.Parse(User.Identity.GetUserId());
            var sService = new SessionService(userId);

            List<Client> clients = sService.GetClientList().ToList();
            ViewBag.ClientId = 
                clients.Select(c => new SelectListItem()
                {
                    Value = c.ClientId.ToString(),
                    Text = c.LastName + c.FirstName,
                    Selected = detail.ClientId == c.ClientId
                }
                );
            var model =
                new SessionEdit
                {
                    SessionId = detail.SessionId,
                    ClientId = detail.ClientId,
                    //FirstName = detail.FirstName,
                    //LastName = detail.LastName,
                    SessionDate = detail.SessionDate,
                    SessionNote = detail.SessionNote,
                    IsDuet = detail.IsDuet,
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
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateSessionService();
            var model = svc.GetSessionById(id);
            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteSession(int id)
        {
            var service = CreateSessionService();
            service.DeleteSession(id);
            TempData["SaveResult"] = "Your Session was deleted";
            return RedirectToAction("Index");
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