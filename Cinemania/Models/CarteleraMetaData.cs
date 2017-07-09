using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cinemania.Models
{
    public class CarteleraMetaData
    {
        
        public int IdCartelera { get; set; }
        [Required(ErrorMessage = "Debe elegir una sede")]
        public int IdSede { get; set; }
        [Required(ErrorMessage = "Debe elegir una pelicula")]
        public int IdPelicula { get; set; }
        [Required(ErrorMessage = "Debe indicar la hora de inicio")]
        //[RegularExpression(@"^(0[1-9]|1[0-2]):[0-5][0-9] [AP]M$", ErrorMessage = "Se debe seleccionar un horario válido")]
        public string HoraInicio { get; set; }
        /*  public TimeSpan _HoraInicio
          {
              get
              {
                  try
                  {
                      DateTime dt = DateTime.Parse(HoraInicio);
                      return dt.TimeOfDay;
                  }
                  catch
                  {
                      return new TimeSpan();
                  }
              }
          }*/
        
        [Required(ErrorMessage = "Debe indicar la fecha de inicio")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/mm/yyyy}")]
        public Nullable<System.DateTime> FechaInicio { get; set; }
        [Required(ErrorMessage = "Debe indicar la fecha de fin")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/mm/yyyy}")]
        public Nullable<System.DateTime> FechaFin { get; set; }
        [Required(ErrorMessage = "Debe indicar el numero de sala")]
        public int NumeroSala { get; set; }
        public bool Lunes { get; set; }
        public bool Martes { get; set; }
        public bool Miercoles { get; set; }
        public bool Jueves { get; set; }
        public bool Viernes { get; set; }
        public bool Sabado { get; set; }
        public bool Domingo { get; set; }
        [Required(ErrorMessage = "Debe indicar la version de la pelicula")]
        public int IdVersion { get; set; }
    }
}