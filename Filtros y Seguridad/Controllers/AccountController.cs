using Filtros_y_Seguridad.Infraestructure;
using Filtros_y_Seguridad.Models;
using Filtros_y_Seguridad.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Filtros_y_Seguridad.Controllers
{
    public class AccountController : Controller
    {
        FiltroSeguridadEntities1 db = new FiltroSeguridadEntities1();
        // GET: Account
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login() 
        {
            return View("Login");
        }

        [HttpPost]
        public ActionResult Login(Usuario model)
        {
            if(ModelState.IsValid)
            {
                IServiceAccount serviceAccount = new ServiceAccount();
                Usuario user = serviceAccount.Login(model);

                if(user != null)
                {
                    // Establecemos la Cookie de Autenticación
                    FormsAuthentication.SetAuthCookie(user.NombreUsuario, false);

                    //Convertimos el Id del Usuario Logueado en un String
                    FormsAuthentication.SetAuthCookie(Convert.ToString(user.Id), true);

                    var authTicket = new FormsAuthenticationTicket(1, user.NombreUsuario, 
                        DateTime.Now, DateTime.Now.AddMinutes(20), false, user.Role.Nombre);
                    string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                    var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                    HttpContext.Response.Cookies.Add(authCookie);

                    return RedirectToAction("Index", "Cursos");
                }
                else
                {
                    ModelState.AddModelError("", "Usuario no Encontrado");
                }
            }
            return RedirectToAction("AccesoDenegado", "Account");
        }

        [HttpGet]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }

        [HttpGet]
        public ActionResult AccesoDenegado()
        {
            return View("AccesoDenegado");
        }

        [HttpGet]
        public ActionResult Registro()
        {
            ViewBag.Roles = db.Role.ToList();
            return View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        //[AuthorizeRole(Enumeration.Role.Instructor)]
        public ActionResult Registro([Bind(Include = "NombreUsuario,Password,RoleId")] Models.Usuario usuarios)
        {
            if (ModelState.IsValid)
            {
                db.Usuario.Add(usuarios);
                db.SaveChanges();
                return RedirectToAction("Login", "Account");

            }
            return View(usuarios);
        }

        [HttpGet]
        [ValidateInput(false)]
        public ActionResult AtaqueXss(string nombre = "prueba")
        {
            ViewBag.Nombre = nombre;
            return View("AtaqueXss");
        }
    }
}