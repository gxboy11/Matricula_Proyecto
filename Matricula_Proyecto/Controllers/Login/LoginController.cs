using Matricula_Proyecto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Matricula_Proyecto.Controllers
{
    public class LoginController : Controller
    {
        public int _estudiante;

        private readonly Context _context = new Context();

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Usuarios user)
        {
            if (ModelState.IsValid)
            {
                var usuario = _context.Usuarios.FirstOrDefault(u => u.usuario_nombre == user.usuario_nombre);

                if (usuario != null && usuario.password == user.password)
                {
                    // Autenticación exitosa
                    Session["UserName"] = usuario.usuario_nombre;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    // Autenticación fallida
                    ModelState.AddModelError("", "Credenciales inválidas. Por favor, intenta nuevamente.");
                }
            }

            return View(user);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Usuarios user)
        {
            if (ModelState.IsValid)
            {
                _context.Usuarios.Add(user);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(user);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var user = _context.Usuarios.SingleOrDefault(u => u.usuario_id == id);

            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }
    }
}