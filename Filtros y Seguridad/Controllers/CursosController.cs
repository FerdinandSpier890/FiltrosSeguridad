using Filtros_y_Seguridad.Filters;
using Filtros_y_Seguridad.Infraestructure;
using Filtros_y_Seguridad.Models;
using Filtros_y_Seguridad.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Filtros_y_Seguridad.Controllers
{
    public class CursosController : Controller
    {
        private FiltroSeguridadEntities1 db = new FiltroSeguridadEntities1();

        // GET: Cursos
        public ActionResult Index()
        {
            var cursos = db.Cursos.Include(c => c.Categorias).Include(c => c.Persona).Include(c => c.Status);
            return View(cursos.ToList());
        }

        //GET: Cursos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cursos cursos = db.Cursos.Find(id);
            if (cursos == null)
            {
                return HttpNotFound();
            }
            return View(cursos);
        }

        //GET Cursos/Create
        [HttpGet]
        //[AuthorizeRole(Enumeration.Role.Instructor)]
        public ActionResult Create()
        {
            //IServiceProfesor profesor = new ServiceProfesor();
            ViewBag.Categorias = db.Categorias.ToList();
            ViewBag.Status = db.Status.ToList();
            ViewBag.Autor = db.Persona.ToList();
            //ViewBag.CategoriaId = new SelectList(db.Categorias, "Id", "Nombre");
            //ViewBag.StatusId = new SelectList(db.Status, "Id", "Nombre");
            //ViewBag.AutorId = new SelectList(db.Persona, "Id", "Nombre");

            return View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        //[AuthorizeRole(Enumeration.Role.Instructor)]
        public ActionResult Create([Bind(Include = "Nombre,Descripcion,Precio,ImgUrl,Ranking,CategoriaId,StatusId,AutorId")] Cursos cursos)
        {
            if (ModelState.IsValid)
            {
                db.Cursos.Add(cursos);
                db.SaveChanges();
                return RedirectToAction("Create");

            }
            else if (ModelState.IsValid)
            {
                cursos.StatusId = (int)Enumeration.Status.Activo;
                db.Cursos.Add(cursos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.CategoriaId = new SelectList(db.Categorias, "Id", "Nombre", cursos.CategoriaId);
            //ViewBag.AutorId = new SelectList(db.Persona, "Id", "Nombre", cursos.AutorId);
            //ViewBag.StatusId = new SelectList(db.Status, "Id", "Nombre", cursos.StatusId);
            return View(cursos);
        }

        //GET: Cursos/Edit/5
        public ActionResult Edit(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cursos cursos = db.Cursos.Find(id); 
            if (cursos == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoriaId = new SelectList(db.Categorias, "Id", "Nombre", cursos.CategoriaId);
            ViewBag.AutorId = new SelectList(db.Persona, "Id", "Nombre", cursos.AutorId);
            ViewBag.StatusId = new SelectList(db.Status, "Id", "Nombre", cursos.StatusId);
            return View(cursos);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Descripcion,Precio,ImgUrl,Ranking,CategoriaId,StatusId,AutorId")] Cursos cursos)
        {
            if(ModelState.IsValid) 
            {
                db.Entry(cursos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoriaId = new SelectList(db.Categorias, "Id", "Nombre", cursos.CategoriaId);
            ViewBag.AutorId = new SelectList(db.Persona, "Id", "Hombre", cursos.AutorId);
            ViewBag.StatusId = new SelectList(db.Status, "Id", "Nombre", cursos.StatusId);
            return View(cursos);
        }

        // GET: Cursos/Delete/5
        public ActionResult Delete(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cursos cursos = db.Cursos.Find(id);
            if(cursos == null)
            {
                return HttpNotFound();
            }
            return View(cursos);
        }

        //POST: Cursos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cursos cursos = db.Cursos.Find(id);
            db.Cursos.Remove(cursos);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        //[AuthorizeRole(Enumeration.Role.Alumno)]
        public ActionResult AddCurso()
        {
            if(User.Identity.IsAuthenticated)
            {
                IServicesCursos cursos = new ServiceCursos();
                return View(cursos.Get());
            }
            return RedirectToAction("Login", "Account");
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