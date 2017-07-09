using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocioDatos.Servicios
{
    public class DalSedes
    {
        Context ctx = new Context();

        //Nueva sede
        public void AgregarSedes(Sedes s)
        {
            ctx.Sedes.Add(s);
            ctx.SaveChanges();
        }

        //Traer una determinada sede de la db
        public Sedes TraerSede (int? id)
        {
            return ctx.Sedes.Find(id);
        }

        //Editar sede
        public void EditarSedes (Sedes s, int id)
        {
            var sed = new Sedes { IdSede = id };

            ctx.Sedes.Attach(sed);
            sed.Nombre = s.Nombre;
            sed.PrecioGeneral = s.PrecioGeneral;
            sed.Direccion = s.Direccion;
            ctx.SaveChanges();
        }

        //Borrar sede
        public void EliminarSede (int id)
        {
            var sed = ctx.Sedes.Find(id);
            ctx.Sedes.Remove(sed);
            ctx.SaveChanges();
        }

        //Traer lista de sedes
        public List<Sedes> ListarSedes()
        {
            List<Sedes> sedes = ctx.Sedes.ToList();

            return sedes;
        }

        //Traer lista de sedes por pelicula y version
        public List<Sedes> ListarPorPeliYCartelera(int IdPelicula, int idVersion)
        {
            List<Carteleras> car = ctx.Carteleras.Where(c => c.IdPelicula == IdPelicula
            && c.IdVersion == idVersion).ToList();

            HashSet<Sedes> sede = new HashSet<Sedes>();

            foreach(var c in car)
            {
                sede.Add(c.Sedes);
            }

            List<Sedes> SedesObtenidas = sede.ToList();

            return SedesObtenidas;
        }

    }
}
