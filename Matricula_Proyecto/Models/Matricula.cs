using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Matricula_Proyecto.Models
{
    public class Matricula
    {
        [Key]
        public int matricula_id { get; set; }

        [Display(Name = "Estudiante")]
        public int estudiante_id { get; set; }

        [Display(Name = "HOrario matriculado")]
        public int horario_id { get; set; }

        [ForeignKey("estudiante_id")]
        public Estudiantes estudiante { get; set; }

        [ForeignKey("horario_id")]
        public Horarios horario { get; set; }
    }
}