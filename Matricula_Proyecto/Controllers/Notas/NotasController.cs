using Matricula_Proyecto.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Matricula_Proyecto.Controllers.Notas
{
    public class NotasController : Controller
    {
        private readonly Context db = new Context();

        public ActionResult Index()
        {
            int idProfesor = (int)Session["ProfesorId"];

            // Obtener los horarios del profesor, incluyendo las propiedades relacionadas
            var horariosProfesor = db.Horarios
                .Where(horario => horario.profesor_id == idProfesor)
                .Include(horario => horario.Curso) // Incluir el Curso relacionado
                .ToList();

            return View(horariosProfesor);
        }

        public ActionResult Calificaciones(int horarioId)
        {
            var calificacionesHorario = db.Calificaciones
                   .Where(calificacion => calificacion.horario_id == horarioId)
                   .Include(calificacion => calificacion.estudiante) // Incluir el estudiante asociado
                   .ToList();

            return View(calificacionesHorario);
        }
        [HttpGet]
        public ActionResult EditarCalificacion(int calificacionId)
        {
            Calificaciones calificacion = db.Calificaciones.Include(c => c.estudiante)
                .FirstOrDefault(c => c.calificacion_id == calificacionId);

            if (calificacion == null)
            {
                return HttpNotFound();
            }

            return View(calificacion);
        }

        [HttpPost]
        public ActionResult EditarCalificacion(Calificaciones calificacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(calificacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.estudiante_id = new SelectList(db.Estudiantes, "carrera_id", "nombre_carrera", calificacion.estudiante_id);
            return View(calificacion);
        }


    }
}