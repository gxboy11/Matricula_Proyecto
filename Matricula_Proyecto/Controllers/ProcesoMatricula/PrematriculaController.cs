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

            // Si no se encontró usuario, estudiante o carrera, podrías redirigir a una página de error o manejarlo según tu lógica
            return RedirectToAction("Error");
        }

        [HttpGet]
        public ActionResult Prematricula()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Prematricula(int horarioId) //Create que guarda informacion de la prematricula en la tabla prematricula >:D
        {
            var horarioSeleccionado = db.Horarios.FirstOrDefault(h => h.horario_id == horarioId);
            if (horarioSeleccionado != null)
            {
                // Agregar el horario seleccionado a la sesión
                List<Horarios> horariosPrematriculados = Session["HorariosPrematriculados"] as List<Horarios>;
                if (horariosPrematriculados == null)
                {
                    horariosPrematriculados = new List<Horarios>();
                }
                horariosPrematriculados.Add(horarioSeleccionado);
                Session["HorariosPrematriculados"] = horariosPrematriculados;
            }

            return RedirectToAction("Index", new { cursoId = horarioSeleccionado.curso_id });
        }

        public ActionResult ListaHorarios(int id)
        {
            var horariosPorCurso = db.Horarios.Where(h => h.curso_id == id).ToList();

            var horarios = horariosPorCurso
                .GroupBy(h => h.dia_semana)
                .OrderBy(g => g.Key)
                .ToList();

            ViewBag.CursoNombre = db.Cursos.FirstOrDefault(c => c.curso_id == id)?.nombre_curso;
            return View(horarios);
        }
    }
}
