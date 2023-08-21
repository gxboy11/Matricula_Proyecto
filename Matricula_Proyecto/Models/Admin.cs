using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Matricula_Proyecto.Models
{
    public class Admin
    {
        [Key]
        public int admin_id { get; set; }

        [Display(Name = "Nombre Admin")]
        public string nombre_admin { get; set; }

        [Display(Name = "Usuario")]
        public int usuario_id { get; set; }

        [ForeignKey("usuario_id")]
        public Usuarios usuario { get; set; }
    }
}