using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cinemania.Models
{
    public class UsuarioMetadata
    {
        [Required]       
        public int cod { get; set; }
        [Required]    
        public string nombre { get; set; }
        [Required]         
        public string claveLogin { get; set; }
    }
}