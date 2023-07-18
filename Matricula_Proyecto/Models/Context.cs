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
        public DbSet<Profesores> Profesores{ get; set; }
    }
}