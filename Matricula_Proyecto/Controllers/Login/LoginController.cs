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
                var roles = _context.Roles.FirstOrDefault(r => r.rol_id == usuario.rol_id);

                if (usuario != null && usuario.password == user.password)
                {
                    // Autenticación exitosa
                    Session["UserName"] = null;
                    Session["UserName"] = usuario.usuario_nombre;

                    if (roles.rol_id != 0 && roles.nombre_rol == "Estudiante") //Estudiante
                    {
                        // Buscar al estudiante correspondiente
                        var estudiante = _context.Estudiantes.FirstOrDefault(e => e.usuario_id == usuario.usuario_id);
                        if (estudiante != null)
                        {
                            Session["EstudianteId"] = null;
                            Session["EstudianteNombre"] = null;
                            Session["EstudianteId"] = estudiante.estudiante_id; // Guardar el nombre del estudiante en la sesión
                            Session["EstudianteNombre"] = estudiante.nombre_estudiante; // Guardar el nombre del estudiante en la sesión
                            Session["Rol"] = roles.nombre_rol; // Guardar el nombre del estudiante en la sesión
                            Session["Rol"] = roles.nombre_rol; // Guardar el nombre del estudiante en la sesión
                        }
                    }
                    if (roles.nombre_rol != null && roles.nombre_rol == "Profesor") //Profesor
                    {
                        var profesor = _context.Profesores.FirstOrDefault(p => p.usuario_id == usuario.usuario_id);
                        if (profesor != null)
                        {
                            Session["ProfesorId"] = null;
                            Session["ProfesorId"] = profesor.profesor_id;
                            Session["ProfesorNombre"] = null;
                            Session["ProfesorNombre"] = profesor.nombre_profesor;
                            Session["Rol"] = roles.nombre_rol;
                            Session["Rol"] = roles.nombre_rol;
                        }
                    }
                    if (roles.nombre_rol != null && roles.nombre_rol == "Admin") //Admin
                    {
                        var admin = _context.Admins.FirstOrDefault(a => a.usuario_id == usuario.usuario_id);
                        if (admin != null)
                        {
                            Session["AdminId"] = null;
                            Session["AdminId"] = admin.admin_id;
                            Session["AdminNombre"] = null;
                            Session["AdminNombre"] = admin.nombre_admin;
                            Session["Rol"] = roles.nombre_rol;
                            Session["Rol"] = roles.nombre_rol;
                        }
                    }
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