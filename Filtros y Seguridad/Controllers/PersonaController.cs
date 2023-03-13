using Filtros_y_Seguridad.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Filtros_y_Seguridad.Controllers
{
    public class PersonaController : Controller
    {
        private FiltroSeguridadEntities1 db = new FiltroSeguridadEntities1();
        // GET: Persona
        public ActionResult Index()
        {
            return View(db.Persona.ToList());
        }

        [HttpGet]
        //[AuthorizeRole(Enumeration.Role.Administrador)]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //[AuthorizeRole(Enumeration.Role.Administrador)] // Es un filtro y se trabaja como una cabecera
        public ActionResult Create([Bind(Include = "Nombre,Apellidos,FechaNacimineto,Email,Descripcion,StatusId,UsuarioId")]Models.Persona personas)
        {
            if (ModelState.IsValid)
            {
                db.Persona.Add(personas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(personas);
        }
    }
}