using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Matricula_Proyecto.Models
{
    public class Cursos
    {
        [Key]
        public int curso_id { get; set; }

        [Display(Name = "Nombre Curso")]
        public string nombre_curso { get; set; }

        [Display(Name = "Descripcion Curso")]
        public string descripcion { get; set; }

        [Display(Name = "Creditos del Curso")]
        public int creditos_curso { get; set; }

        [Display(Name = "Precio del curso")]
        public float precio_curso { get; set; }



        [Display(Name = "Plan de carrera al que pertenece")]
        public int carrera_id { get; set; }

        [ForeignKey("carrera_id")]
        public Carreras carrera { get; set; }

        [Display(Name = "Profesor")]
        public int ProfesorId { get; set; }

        [ForeignKey("ProfesorId")]
        public Profesor Profesor { get; set; }
    }
}