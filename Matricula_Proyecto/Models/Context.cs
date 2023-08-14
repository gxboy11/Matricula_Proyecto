using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Matricula_Proyecto.Models
{
    public class Context : DbContext
    {
        public Context() : base("Context") { }

        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Estudiantes> Estudiantes { get; set; }
        public DbSet<Profesores> Profesores { get; set; }
        public DbSet<Cursos> Cursos { get; set; }
        public DbSet<Prematricula> Prematricula { get; set; }
        public DbSet<Matricula> Matricula { get; set; }
        public DbSet<Carreras> Carrera { get; set; }

        public System.Data.Entity.DbSet<Matricula_Proyecto.Models.Horarios> Horarios { get; set; }
    }
}