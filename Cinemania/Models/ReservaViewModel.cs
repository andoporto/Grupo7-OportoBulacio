using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Cinemania.Models;

namespace Cinemania.Models
{
    
    public class ReservaViewModel
    {
        [Required]
        public int IdReserva { get; set; }
        [Required(ErrorMessage = "Debe seleccionar una sede")]
        public int IdSede { get; set; }
        [Required]
        public int IdVersion { get; set; }
        [Required]
        public int IdPelicula { get; set; }
        [Required]
        public int HoraInicio { get; set; }
        [Required]
        public int FechaInicio { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/mm/yyyy}")]
        public Nullable<System.DateTime> FechaHoraInicio { get; set; }
        [Required]
        public int Email { get; set; }
        [Required]
        public int IdTipoDocumento { get; set; }
        [Required]
        public string NumeroDocumento { get; set; }
        [Required]
        public int CantidadEntradas { get; set; }
        [Required]
        public DateTime FechaCarga { get; set; }
    }
}