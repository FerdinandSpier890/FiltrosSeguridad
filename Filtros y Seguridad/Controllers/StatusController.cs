using Filtros_y_Seguridad.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Filtros_y_Seguridad.Controllers
{
    public class StatusController : Controller
    {
        private FiltroSeguridadEntities1 db = new FiltroSeguridadEntities1();

        // GET: Status
        public ActionResult Index()
        {
            return View(db.Status.ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "Nombre,Descipcion")] Models.Status status)
        {
            if (ModelState.IsValid)
            {
                db.Status.Add(status);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(status);
        }
    }
}