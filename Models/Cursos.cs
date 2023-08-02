﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
    }
}