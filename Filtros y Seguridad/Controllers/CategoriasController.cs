using Filtros_y_Seguridad.Filters;
using Filtros_y_Seguridad.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Filtros_y_Seguridad.Controllers
{
    public class CategoriasController : Controller
    {
        private FiltroSeguridadEntities1 db = new FiltroSeguridadEntities1();

        //[AuthorizeRole(Enumeration.Role.Administrador)]
        // GET: Categorias
        public ActionResult Index()
        {
            return View(db.Categorias.ToList());
        }

        //GET: Categorias/Details/5
        public ActionResult Details(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categorias categorias = db.Categorias.Find(id);
            if(categorias == null)
            {
                return HttpNotFound();
            }
            return View(categorias);
        }

        //GET: Categorias/Create
        [HttpGet]
        //[AuthorizeRole(Enumeration.Role.Administrador)]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //[AuthorizeRole(Enumeration.Role.Administrador)] // Es un filtro y se trabaja como una cabecera
        public ActionResult Create([Bind(Include = "Nombre,Descripcion")] Categorias categorias)
        {
            if(ModelState.IsValid)
            {
                db.Categorias.Add(categorias);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categorias);
        }

        // GET: Categorias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categorias categorias = db.Categorias.Find(id);
            if (categorias == null)
            {
                return HttpNotFound();
            }
            return View(categorias);
        }

        // POST: Categorias/Edit/5
        // Para protegerese de los ataques de publicación excesiva, habilitar las propiedades especificas 
        // para más detalle, ver https://go.microsoft.com/fwlink/?LinkId=317598
        public ActionResult Edit([Bind(Include = "Id,Nombre,Descipcion")] Categorias categorias)
        {
            if (ModelState.IsValid)
            {
                db.Entry(categorias).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categorias);
        }

        // GET: Categorias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categorias categorias = db.Categorias.Find(id);
            if (categorias == null)
            {
                return HttpNotFound();
            }
            return View(categorias);
        }

        // POST: Categorias/Delete/5
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            Categorias categorias = db.Categorias.Find();
            db.Categorias.Remove(categorias);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if(disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}