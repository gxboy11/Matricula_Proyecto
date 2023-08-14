using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Matricula_Proyecto.Models
{
    public class Prematricula
    {
        [Key]
        public int prematricula_id { get; set; }

        [Display(Name = "Estudiante")]
        public int estudiante_id { get; set; }

        [Display(Name = "Horario a matricular")]
        public int horario_id { get; set; }

        [ForeignKey("estudiante_id")]
        public Estudiantes Estudiante { get; set; }

        [ForeignKey("horario_id")]
        public Horarios horario { get; set; }
    }
}