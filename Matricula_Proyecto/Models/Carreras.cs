using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Matricula_Proyecto.Models
{
    public class Carreras
    {
        [Key]
        public int carrera_id { get; set; }

        public string nombre_carrera { get; set; }

        public int duracion { get; set; }

        public string descripcion { get; set; }
    }
}