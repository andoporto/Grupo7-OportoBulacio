using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cinemania.Models
{
    public class SedeMetadata
    {
        public int IdSede { get; set; }
        [Required]   
        public string Nombre { get; set; }
        
        [Required(ErrorMessage = "Debe elegir un nombre")]
        public string Direccion { get; set; }
        [Required]
        public double PrecioGeneral { get; set; }
    }
}