using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocioDatos.Servicios
{
    public class DalReservas
    {
        Context ctx = new Context();

        //Guarda una nueva reserva en la db
        public void AgregarReserva (Reservas r)
        {
            r.FechaCarga = DateTime.Now;

            ctx.Reservas.Add(r);
            ctx.SaveChanges();
        }

        //Trae una lista de reservas de la db que estén entra las dos fechas
        public List<Reservas> TraerReservasFechas(DateTime inicio, DateTime fin)
        {
            List<Reservas> reporte = ctx.Reservas.Where(r => (r.FechaHoraInicio > inicio
                && r.FechaHoraInicio < fin)).ToList();

            return reporte;
        }
    }
}
