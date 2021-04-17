using Microsoft.AspNet.Identity;
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

        private EquipmentService CreateEquipmentService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new EquipmentService(userId);
            return service;

        }
    }
}