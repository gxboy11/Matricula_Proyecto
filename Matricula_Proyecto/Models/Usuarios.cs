using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Matricula_Proyecto.Models
{
    public class Usuarios
    {
        [Key]
        public int usuario_id { get; set; }

        [Display(Name = "Nombre de usuario")]
        public string usuario_nombre { get; set; }

        [Display(Name = "Contraseña")]
        public string password { get; set; }

        [Display(Name = "Rol")]
        public int rol_id { get; set; }

        [Display(Name = "Estado de Usuario (Activo, Inactivo)")]
        public bool estado { get; set; }

        [ForeignKey("rol_id")]
        public Roles rol { get; set; }

    }
}