using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Matricula_Proyecto.Models
{
    public class Roles
    {
        [Key]
        public int rol_id { get; set; }

        [Display(Name = "Rol")]
        public string nombre_rol { get; set; }

        [Display(Name = "Descripcion")]
        public string descripcion_rol { get; set; }
    }
}