﻿using System;
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
        public ActionResult Index()
        {
            // Obtener el nombre de usuario de la sesión
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

                        // Puedes enviar cursosCarrera a la vista para mostrarlos
                        return View(cursosCarrera);
                    }
                }
            }

            // Si no se encontró usuario, estudiante o carrera, podrías redirigir a una página de error o manejarlo según tu lógica
            return RedirectToAction("Error");
        }
    }
}
