using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;
using Matricula_Proyecto.Models;

namespace Matricula_Proyecto.Controllers
{
    public class EstudiantesController : Controller
    {
        private Context db = new Context();

        // GET: Estudiantes
        public ActionResult Index()
        {
            var estudiantes = db.Estudiantes.Include(e => e.Carrera).Include(e => e.usuario);
            return View(estudiantes.ToList());
        }

        // GET: Estudiantes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estudiantes estudiantes = db.Estudiantes.Find(id);
            if (estudiantes == null)
            {
                return HttpNotFound();
            }
            return View(estudiantes);
        }

        // GET: Estudiantes/Create
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.carrera_id = new SelectList(db.Carrera, "carrera_id", "nombre_carrera");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "estudiante_id,nombre_estudiante,apellido_estudiante,correo_estudiante,fecha_nacimiento_estudiante,direccion_estudiante,telefono_estudiante,carrera_id")] Estudiantes estudiante)
        {
            if (ModelState.IsValid)
            {
                Session["EstudianteEnEspera"] = estudiante; // Almacena el estudiante en la sesión
                return RedirectToAction("CrearUsuario");
            }
            return View(estudiante);
        }

        [HttpGet]
        public ActionResult CrearUsuario()
        {
            ViewBag.rol_id = new SelectList(db.Roles, "rol_id", "nombre_rol");
            return View();
        }

        [HttpPost]
        public ActionResult CrearUsuario(Usuarios usuario)
        {
            if (ModelState.IsValid)
            {
                var estudianteEnEspera = (Estudiantes)Session["EstudianteEnEspera"]; // Recupera el estudiante de la sesión

                // Guardar el usuario en la base de datos
                db.Usuarios.Add(usuario);
                db.SaveChanges();

                // Asociar el usuario con el estudiante
                usuario.estado = true;
                estudianteEnEspera.usuario_id = usuario.usuario_id;
                db.Estudiantes.Add(estudianteEnEspera);
                db.SaveChanges();

                // Limpiar la información de la sesión
                Session.Remove("EstudianteEnEspera");

                return RedirectToAction("Index");
            }
            return View(usuario);
        }



        // GET: Estudiantes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estudiantes estudiantes = db.Estudiantes.Find(id);
            if (estudiantes == null)
            {
                return HttpNotFound();
            }
            ViewBag.carrera_id = new SelectList(db.Carrera, "carrera_id", "nombre_carrera", estudiantes.carrera_id);
            ViewBag.usuario_id = new SelectList(db.Usuarios, "usuario_id", "usuario_nombre", estudiantes.usuario_id);
            return View(estudiantes);
        }

        // POST: Estudiantes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "estudiante_id,nombre_estudiante,apellido_estudiante,correo_estudiante,fecha_nacimiento_estudiante,direccion_estudiante,telefono_estudiante,carrera_id,usuario_id")] Estudiantes estudiantes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estudiantes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.carrera_id = new SelectList(db.Carrera, "carrera_id", "nombre_carrera", estudiantes.carrera_id);
            ViewBag.usuario_id = new SelectList(db.Usuarios, "usuario_id", "usuario_nombre", estudiantes.usuario_id);
            return View(estudiantes);
        }

        // GET: Estudiantes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estudiantes estudiantes = db.Estudiantes.Find(id);
            if (estudiantes == null)
            {
                return HttpNotFound();
            }
            return View(estudiantes);
        }

        // POST: Estudiantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Estudiantes estudiantes = db.Estudiantes.Find(id);
            db.Estudiantes.Remove(estudiantes);
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
