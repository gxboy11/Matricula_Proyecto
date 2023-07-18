using Matricula_Proyecto.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Matricula_Proyecto.Controllers
{
    public class EstudiantesController : Controller
    {
        private readonly Context _context = new Context();

        // GET: Estudiantes
        public ActionResult Index()
        {
            var estudiantes = _context.Estudiantes.ToList();
            return View(estudiantes);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Estudiantes estudiante)
        {
            if (ModelState.IsValid)
            {
                _context.Estudiantes.Add(estudiante);
                _context.SaveChanges();
            }
            return View(estudiante);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var estudiante = _context.Estudiantes.SingleOrDefault(e => e.estudiante_id == id);

            if (estudiante == null)
            {
                return HttpNotFound();
            }
            return View(estudiante);
        }

        [HttpPost]
        public ActionResult Edit(Estudiantes estudiante) //Guarda modificacion
        {
            if (ModelState.IsValid)
            {
                _context.Entry(estudiante).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(estudiante);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var estudiante = _context.Estudiantes.SingleOrDefault(e => e.estudiante_id == id);

            if (estudiante == null)
            {
                return HttpNotFound();
            }
            return View(estudiante);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var estudiante = _context.Estudiantes.SingleOrDefault(e => e.estudiante_id == id);

            if (estudiante == null)
            {
                return HttpNotFound();
            }
            return View(estudiante);
        }

        [HttpPost]
        public ActionResult Delete(int id) //Guarda modificacion
        {
            var customer = _context.Estudiantes.SingleOrDefault(e => e.estudiante_id == id);
            _context.Estudiantes.Remove(customer ?? throw new InvalidOperationException());
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}