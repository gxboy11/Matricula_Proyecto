using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using Matricula_Proyecto.Models;

namespace Matricula_Proyecto.Controllers.Matricular
{
    public class PrematriculaController : Controller
    {
        private Context db = new Context();

        // GET: Horarios
        public ActionResult Index() //Lista filtrada por la carrera del estudiante 
        {
            try
            {
                string userName = Session["UserName"] as string;

                // Buscar al usuario en la tabla de Usuarios
                Usuarios usuario = db.Usuarios.FirstOrDefault(u => u.usuario_nombre == userName);

                if (usuario != null)
                {
                    // Buscar al usuario en la tabla de Estudiantes
                    Estudiantes estudiante = db.Estudiantes.FirstOrDefault(e => e.usuario_id == usuario.usuario_id);

                    if (estudiante != null)
                    {
                        // Obtener la carrera que está cursando el estudiante
                        Carreras carrera = db.Carrera.FirstOrDefault(c => c.carrera_id == estudiante.carrera_id);

                        if (carrera != null)
                        {
                            // Obtener los cursos de la carrera
                            List<Cursos> cursosCarrera = db.Cursos.Where(curso => curso.carrera_id == carrera.carrera_id).ToList();

                            return View(cursosCarrera);
                        }
                    }
                }
                return RedirectToAction("ErrorGeneral", "Error");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("ErrorGeneral", "Error");
            }
        }

        [HttpGet]
        public ActionResult Prematricula()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Prematricula(int horarioId)
        {
            try
            {
                var horarioSeleccionado = db.Horarios.FirstOrDefault(h => h.horario_id == horarioId);
                if (horarioSeleccionado != null)
                {
                    // Agregar el ID del curso a la lista en la sesión
                    List<int> horarioPrematriculados = Session["HorariosPrematriculados"] as List<int> ?? new List<int>();
                    List<int> cursoPrematriculados = Session["HorariosPrematriculados"] as List<int> ?? new List<int>();
                    horarioPrematriculados.Add(horarioId);
                    cursoPrematriculados.Add(horarioSeleccionado.curso_id);
                    Session["HorariosPrematriculados"] = horarioPrematriculados;
                    Session["CursosPrematriculados"] = cursoPrematriculados;
                }

                return RedirectToAction("Index", new { cursoId = horarioSeleccionado.curso_id });
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("ErrorGeneral", "Error");
            }
        }

        public ActionResult ListaHorarios(int id)
        {
            try
            {
                var horariosPorCurso = db.Horarios
                    .Where(h => h.curso_id == id)
                    .Include(h => h.Profesor)
                    .ToList();

                var horarios = horariosPorCurso
                    .GroupBy(h => h.dia_semana)
                    .OrderBy(g => g.Key)
                    .ToList();

                ViewBag.CursoNombre = db.Cursos.FirstOrDefault(c => c.curso_id == id)?.nombre_curso;
                return View(horarios);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("ErrorGeneral", "Error");
            }
        }



        public ActionResult Matricular()
        {
            //try
            //{
            int idEstudiante = (int)Session["EstudianteId"];

            if (Session["HorariosPrematriculados"] != null)
            {
                List<int> cursosPrematriculados = (List<int>)Session["HorariosPrematriculados"];

                foreach (int idHorario in cursosPrematriculados)
                {
                    Matricula matricula = new Matricula
                    {
                        estudiante_id = idEstudiante,
                        horario_id = idHorario
                    };

                    db.Matricula.Add(matricula);

                    // Crear una nueva calificación asociada a la matrícula
                    Calificaciones calificacion = new Calificaciones
                    {
                        estudiante_id = idEstudiante,
                        horario_id = idHorario,
                        nota_curso = 0
                    };

                    db.Calificaciones.Add(calificacion);
                }

                db.SaveChanges();
                Session["HorariosPrematriculados"] = null;
            }

            return RedirectToAction("CursosMatriculados"); // Redirige a Mis Cursos
        }
        //catch (Exception ex)
        //{
        //    TempData["ErrorMessage"] = ex.Message;
        //    return RedirectToAction("ErrorGeneral", "Error");
        //}
        //}



        public ActionResult CursosMatriculados()
        {
            try
            {
                // Obtener el ID del estudiante desde la sesión
                int idEstudiante = (int)Session["EstudianteId"];

                // Buscar las matrículas del estudiante
                var matriculasEstudiante = db.Matricula
                    .Include(m => m.horario)
                    .Include(m => m.horario.Curso)
                    .Include(m => m.horario.Profesor)
                    .Where(m => m.estudiante_id == idEstudiante)
                    .ToList();

                return View(matriculasEstudiante);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("ErrorGeneral", "Error");
            }
        }
    }
}
