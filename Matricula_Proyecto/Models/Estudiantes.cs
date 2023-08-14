using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Matricula_Proyecto.Models
{
    public class Estudiantes
    {
        [Key]
        public int estudiante_id { get; set; }

        [Display(Name = "Nombre Estudiante")]
        public string nombre_estudiante { get; set; }

        [Display(Name = "Apellido Estudiante")]
        public string apellido_estudiante { get; set; }

        [Display(Name = "Correo Electronico")]
        public string correo_estudiante { get; set; }

        [Display(Name = "Fecha Nacimiento")]
        public string fecha_nacimiento_estudiante { get; set; }

        [Display(Name = "Direccion")]
        public string direccion_estudiante { get; set; }

        [Display(Name = "Telefono")]
        public string telefono_estudiante { get; set; }

        public int carrera_id { get; set; }

        public int usuario_id { get; set; }

        [ForeignKey("usuario_id")]
        public Usuarios usuario { get; set; }

        [ForeignKey("carrera_id")]
        public Carreras Carrera { get; set; }





    }
}