using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CapaNegocioDatos;
using CapaNegocioDatos.Servicios;

namespace Cinemania.Models.Servicios
{
    public abstract class DiaService
    {   
        public static List<Dias> sacarDiasReservas(int IdPelicula, int IdSede, int IdVersion)
        {
            DalCartelera DalCar = new DalCartelera();

            var traerCartelera = DalCar.CarteleraPeliSedeYVersion(IdPelicula, IdSede, IdVersion);

            List<Dias> listaDias = new List<Dias>();

            DateTime inicio = traerCartelera.FechaInicio;
            DateTime fin = traerCartelera.FechaFin;

            for (DateTime fecha = inicio; fecha <= fin; fecha.AddDays(1))
            {
                string dia = fecha.ToString("dd-mm-yyyy");
                listaDias.Add(new Dias() { Id = dia, Dia = dia });
            }

            return listaDias;
        }
    }
}