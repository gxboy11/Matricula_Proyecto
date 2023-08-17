using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Matricula_Proyecto.Models;

namespace Matricula_Proyecto.Controllers.API
{
    public class HorariosController : ApiController
    {
        private Context db = new Context();

        // GET: api/Horarios
        public IQueryable<Horarios> GetHorarios()
        {
            return db.Horarios;
        }

        // GET: api/Horarios/5
        [ResponseType(typeof(Horarios))]
        public IHttpActionResult GetHorarios(int id)
        {
            Horarios horarios = db.Horarios.Find(id);
            if (horarios == null)
            {
                return NotFound();
            }

            return Ok(horarios);
        }

        // PUT: api/Horarios/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutHorarios(int id, Horarios horarios)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != horarios.horario_id)
            {
                return BadRequest();
            }

            db.Entry(horarios).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HorariosExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Horarios
        [ResponseType(typeof(Horarios))]
        public IHttpActionResult PostHorarios(Horarios horarios)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Horarios.Add(horarios);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = horarios.horario_id }, horarios);
        }

        // DELETE: api/Horarios/5
        [ResponseType(typeof(Horarios))]
        public IHttpActionResult DeleteHorarios(int id)
        {
            Horarios horarios = db.Horarios.Find(id);
            if (horarios == null)
            {
                return NotFound();
            }

            db.Horarios.Remove(horarios);
            db.SaveChanges();

            return Ok(horarios);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HorariosExists(int id)
        {
            return db.Horarios.Count(e => e.horario_id == id) > 0;
        }
    }
}