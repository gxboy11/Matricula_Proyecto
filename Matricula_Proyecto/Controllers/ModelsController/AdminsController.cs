using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Matricula_Proyecto.Models;

namespace Matricula_Proyecto.Controllers.ModelsController
{
    public class AdminsController : Controller
    {
        private Context db = new Context();

        // GET: Admins
        public ActionResult Index()
        {
            var admins = db.Admins.Include(a => a.usuario);
            return View(admins.ToList());
        }

        // GET: Admins/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Admin admin = db.Admins.Find(id);
            if (admin == null)
            {
                return HttpNotFound();
            }
            return View(admin);
        }

        // GET: Admins/Create
        public ActionResult Create()
        {
            ViewBag.usuario_id = new SelectList(db.Usuarios, "usuario_id", "usuario_nombre");
            return View();
        }

        // POST: Admins/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "admin_id,nombre_admin,usuario_id")] Admin admin)
        {
            if (ModelState.IsValid)
            {
                Session["AdminEnEspera"] = admin; // Almacena el estudiante en la sesión
                return RedirectToAction("CrearUsuario");
            }
            return View(admin);
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
                var adminEnEspera = (Admin)Session["AdminEnEspera"]; // Recupera el admin de la sesión

                // Guardar el admin en la base de datos
                db.Usuarios.Add(usuario);
                db.SaveChanges();

                // Asociar el usuario con el admin
                usuario.estado = true;
                adminEnEspera.usuario_id = usuario.usuario_id;
                db.Admins.Add(adminEnEspera);
                db.SaveChanges();

                // Limpiar la información de la sesión
                Session.Remove("AdminEnEspera");

                return RedirectToAction("Index");
            }
            return View(usuario);
        }

        // GET: Admins/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Admin admin = db.Admins.Find(id);
            if (admin == null)
            {
                return HttpNotFound();
            }
            ViewBag.usuario_id = new SelectList(db.Usuarios, "usuario_id", "usuario_nombre", admin.usuario_id);
            return View(admin);
        }

        // POST: Admins/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "admin_id,nombre_admin,usuario_id")] Admin admin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(admin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.usuario_id = new SelectList(db.Usuarios, "usuario_id", "usuario_nombre", admin.usuario_id);
            return View(admin);
        }

        // GET: Admins/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Admin admin = db.Admins.Find(id);
            if (admin == null)
            {
                return HttpNotFound();
            }
            return View(admin);
        }

        // POST: Admins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Admin admin = db.Admins.Find(id);
            db.Admins.Remove(admin);
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
