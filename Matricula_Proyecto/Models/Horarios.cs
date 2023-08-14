using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Matricula_Proyecto.Models
{
    public class Horarios
    {
        [Key]
        public int horario_id { get; set; }

        [Display(Name = "Curso")]
        public int curso_id { get; set; }

        [Display(Name = "Profesor")]
        public int profesor_id { get; set; }

        [Display(Name = "Dia Semana")]
        public string dia_semana { get; set; }


        [Display(Name = "Hora inicio")]
        public TimeSpan hora_inicio { get; set; }

        [Display(Name = "Hora final")]
        public TimeSpan hora_final { get; set; }

        /* COMO DEFINIR LOS HORARIOS
        
        HoraInicio = new TimeSpan(8, 30, 0),   // 8:30 AM
        HoraFinal = new TimeSpan(10, 0, 0)     // 10:00 AM

        */


        //Relaciones Llaves foraneas
        [ForeignKey("curso_id")]
        public Cursos Curso { get; set; }

        [ForeignKey("profesor_id")]
        public Profesores Profesor { get; set; }
    }
}