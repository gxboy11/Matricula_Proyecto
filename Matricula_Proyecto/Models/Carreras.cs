using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Matricula_Proyecto.Models
{
    public class Carreras
    {
        [Key]
        public int carrera_id { get; set; }

        [Display(Name = "Nombre Carrera")]
        public string nombre_carrera { get; set; }

        [Display(Name = "Duracion de la carrera")]
        public int duracion { get; set; }

        [Display(Name = "Descripcion de la carrera")]
        public string descripcion { get; set; }

    }
}