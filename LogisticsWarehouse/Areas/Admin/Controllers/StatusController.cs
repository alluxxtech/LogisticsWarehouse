using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.Abstract;
using BLL.Concrete;
using BLL.Models.Admin;

namespace LogisticsWarehouse.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class StatusController : Controller
    {
        private IStatusProvider _statusProvider;
        public StatusController()
        {
            _statusProvider = new StatusProvider();
        }

        public StatusController(IStatusProvider statusProvider)
        {
            _statusProvider = statusProvider;
        }
        // GET: Admin/Status
        public ActionResult Index()
        {
            return View(_statusProvider.GetModels());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(StatusCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = _statusProvider.AddStatus(model);
            if (result == StatusResult.Success)
            {
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Something went wrong");
            return View(model);
        }
    }
}