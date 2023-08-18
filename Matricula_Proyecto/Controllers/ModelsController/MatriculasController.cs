using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Matricula_Proyecto.Models;

namespace Matricula_Proyecto.Controllers
{
    public class MatriculasController : Controller
    {
        private Context db = new Context();

        // GET: Matriculas
        public ActionResult Index()
        {
            var matricula = db.Matricula.Include(m => m.estudiante).Include(m => m.horario);
            return View(matricula.ToList());
        }

        // GET: Matriculas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Matricula matricula = db.Matricula.Find(id);
            if (matricula == null)
            {
                return HttpNotFound();
            }
            return View(matricula);
        }

        // GET: Matriculas/Create
        public ActionResult Create()
        {
            ViewBag.estudiante_id = new SelectList(db.Estudiantes, "estudiante_id", "nombre_estudiante");
            ViewBag.horario_id = new SelectList(db.Horarios, "horario_id", "dia_semana");
            return View();
        }

        // POST: Matriculas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "matricula_id,estudiante_id,horario_id")] Matricula matricula)
        {
            if (ModelState.IsValid)
            {
                db.Matricula.Add(matricula);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.estudiante_id = new SelectList(db.Estudiantes, "estudiante_id", "nombre_estudiante", matricula.estudiante_id);
            ViewBag.horario_id = new SelectList(db.Horarios, "horario_id", "dia_semana", matricula.horario_id);
            return View(matricula);
        }

        // GET: Matriculas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Matricula matricula = db.Matricula.Find(id);
            if (matricula == null)
            {
                return HttpNotFound();
            }
            ViewBag.estudiante_id = new SelectList(db.Estudiantes, "estudiante_id", "nombre_estudiante", matricula.estudiante_id);
            ViewBag.horario_id = new SelectList(db.Horarios, "horario_id", "dia_semana", matricula.horario_id);
            return View(matricula);
        }

        // POST: Matriculas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "matricula_id,estudiante_id,horario_id")] Matricula matricula)
        {
            if (ModelState.IsValid)
            {
                db.Entry(matricula).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.estudiante_id = new SelectList(db.Estudiantes, "estudiante_id", "nombre_estudiante", matricula.estudiante_id);
            ViewBag.horario_id = new SelectList(db.Horarios, "horario_id", "dia_semana", matricula.horario_id);
            return View(matricula);
        }

        // GET: Matriculas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Matricula matricula = db.Matricula.Find(id);
            if (matricula == null)
            {
                return HttpNotFound();
            }
            return View(matricula);
        }

        // POST: Matriculas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Matricula matricula = db.Matricula.Find(id);
            db.Matricula.Remove(matricula);
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
