using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cinemania.Models
{
    public class PeliculaMetadata
    {
        public int IdPelicula { get; set; }        
        [Required(ErrorMessage = "El Nombre no debe estar vacío")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "La Descripcion no debe estar vacía")]
        public int Descripcion { get; set; }
        [Required(ErrorMessage = "Debe elegir una clasificación")]
        public int IdCalificacion { get; set; }
        [Required(ErrorMessage = "Debe elegir un género")]       
        public int IdGenero { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/mm/yyyy}")]             
        public Nullable<System.DateTime> FechaCarga { get; set; }
    }
}