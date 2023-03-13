using Filtros_y_Seguridad.Filters;
using Filtros_y_Seguridad.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Filtros_y_Seguridad.Controllers
{
    public class RolesController : Controller
    {
        private FiltroSeguridadEntities1 db = new FiltroSeguridadEntities1();

        // GET: Roles
        public ActionResult Index()
        {
            return View(db.Role.ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "Nombre,Descripcion")] Models.Role roles)
        {
            if (ModelState.IsValid)
            {
                db.Role.Add(roles);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(roles);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Models.Role roles = db.Role.Find(id);
            if (roles == null)
            {
                return HttpNotFound();
            }
            return View(roles);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Descripcion")] Models.Role roles)
        {
            if (ModelState.IsValid)
            {
                db.Entry(roles).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            return View(roles);
        }

        // GET: Roles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Models.Role roles = db.Role.Find(id);
            if (roles == null)
            {
                return HttpNotFound();
            }
            return View(roles);
        }

        //POST: Cursos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Models.Role roles = db.Role.Find(id);
            db.Role.Remove(roles);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}