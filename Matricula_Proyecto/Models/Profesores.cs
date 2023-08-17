using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Matricula_Proyecto.Models
{
    public class Profesores
    {
        [Key]
        public int profesor_id { get; set; }

        [Display(Name = "Nombre Profesor")]
        public string nombre_profesor { get; set; }

        [Display(Name = "Apellido Profesor")]
        public string apellido_profesor { get; set; }

        [Display(Name = "Correo Electronico")]
        public string correo_electronico { get; set; }

        [Display(Name = "Fecha Nacimiento")]
        public string fecha_nacimiento_profesor { get; set; }

        [Display(Name = "Direccion")]
        public string direccion { get; set; }

        [Display(Name = "Telefono")]
        public string telefono_profesor { get; set; }

        [Display(Name = "Area Especializacion")]
        public string area_espec { get; set; }



        public int usuario_id { get; set; }

        [ForeignKey("usuario_id")]
        public Usuarios usuario { get; set; }

    }
}