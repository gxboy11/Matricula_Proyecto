﻿using Matricula_Proyecto.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Matricula_Proyecto.Controllers
{
    public class ProfesoresController : Controller
    {
        private readonly Context _context = new Context();

        // GET: Profesores
        public ActionResult Index()
        {
            var profesor = _context.Profesores.ToList();
            return View(profesor);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Profesores profesor)
        {
            if (ModelState.IsValid)
            {
                _context.Profesores.Add(profesor);
                _context.SaveChanges();
            }
            return View(profesor);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var profesor = _context.Profesores.SingleOrDefault(e => e.profesor_id == id);

            if (profesor == null)
            {
                return HttpNotFound();
            }
            return View(profesor);
        }

        [HttpPost]
        public ActionResult Edit(Profesores profesor) //Guarda modificacion
        {
            if (ModelState.IsValid)
            {
                _context.Entry(profesor).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(profesor);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var profesor = _context.Profesores.SingleOrDefault(e => e.profesor_id == id);

            if (profesor == null)
            {
                return HttpNotFound();
            }
            return View(profesor);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var profesor = _context.Profesores.SingleOrDefault(e => e.profesor_id == id);

            if (profesor == null)
            {
                return HttpNotFound();
            }
            return View(profesor);
        }

        [HttpPost]
        public ActionResult Delete(int id) //Guarda modificacion
        {
            var customer = _context.Profesores.SingleOrDefault(e => e.profesor_id == id);
            _context.Profesores.Remove(customer ?? throw new InvalidOperationException());
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}