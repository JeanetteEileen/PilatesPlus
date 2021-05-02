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
    public class EquipmentController : Controller
    {
        // GET: Equipment
        public ActionResult Index()
        {
            var service = CreateEquipmentService();
            var model = service.GetEquipments();

            return View(model);
        }
        // GET: for Equipment Create
        public ActionResult Create()
        {
            var service = CreateEquipmentService();

            List<Session> sessions = service.GetSessionList().ToList();

            ViewBag.EquipmentSessionId
                = sessions.Select(c => new SelectListItem()
                {
                    Value = c.SessionId.ToString(),
                    Text = c.SessionId.ToString() + " " + c.Client.LastName + " " + c.SessionDate.ToString()
                }
                );

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
        public ActionResult Edit(int id)
        {
            var service = CreateEquipmentService();
            var detail = service.GetEquipmentById(id);
            var model = new EquipmentEdit
            {
                EquipmentSessionId = detail.EquipmentSessionId,
                //ClientId = detail.ClientId,
                Reformer = detail.Reformer,
                Cadilac = detail.Cadilac,
                Mat = detail.Mat,
                LadderBarrel = detail.LadderBarrel,
                PediPole = detail.PediPole,
                MagicCircle = detail.MagicCircle,
                ToeExerciser = detail.ToeExerciser,
                SmallBarrel = detail.SmallBarrel,
                ArmChair = detail.ArmChair,
                SpineCorrector = detail.SpineCorrector,
                WundaChair = detail.WundaChair,

            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EquipmentEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.EquipmentSessionId != id)
            {
                ModelState.AddModelError("", "Id's Mismatch");
                return View(model);
            }

            var service = CreateEquipmentService();

            if (service.UpdateEquipment(model))
            {
                TempData["SaveResult"] = "Your Client was updated.";
                return RedirectToAction("Index");
            }
            return View();
        }
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateEquipmentService();
            var model = svc.GetEquipmentById(id);
            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteEquipment(int id)
        {
            var service = CreateEquipmentService();
            service.DeleteEquipment(id);
            TempData["SaveResult"] = "Your Equipment entry was deleted";
            return RedirectToAction("Index");
        }

        private EquipmentService CreateEquipmentService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new EquipmentService(userId);
            return service;

        }
    }
}