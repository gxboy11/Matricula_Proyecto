using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Linq;
using System.Web;

namespace Matricula_Proyecto.Models
{
    public class Calificaciones
    {
        [Key]
        public int calificacion_id { get; set; }

        [Display(Name = "Estudiante")]
        public int estudiante_id { get; set; }

        [Display(Name = "Horario")]
        public int horario_id { get; set; }

        [Display(Name = "Nota")]
        public float nota_curso { get; set; }


        [ForeignKey("estudiante_id")]
        public Estudiantes estudiante { get; set; }

        [ForeignKey("horario_id")]
        public Horarios horario { get; set; }
    }
}