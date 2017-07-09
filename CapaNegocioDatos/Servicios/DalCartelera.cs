using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocioDatos.Servicios
{
    public class DalCartelera
    {
        Context ctx = new Context();

        //Agregar nueva cartelera
        public void AgregarCarteleras(Carteleras c)
        {
            c.FechaCarga = DateTime.Now;
            ctx.Carteleras.Add(c);
            ctx.SaveChanges();
        }

        //Editar una cartelera
        public void EditarCartelera(int id, Carteleras c)
        {
            var cartEdit = ctx.Carteleras.Find(id);

            cartEdit.IdSede = c.IdSede;
            cartEdit.IdPelicula = c.IdPelicula;
            cartEdit.HoraInicio = c.HoraInicio;
            cartEdit.FechaInicio = c.FechaInicio;
            cartEdit.FechaFin = c.FechaFin;
            cartEdit.NumeroSala = c.NumeroSala;
            cartEdit.IdVersion = c.IdVersion;
            cartEdit.Lunes = c.Lunes;
            cartEdit.Martes = c.Martes;
            cartEdit.Miercoles = c.Miercoles;
            cartEdit.Jueves = c.Jueves;
            cartEdit.Viernes = c.Viernes;
            cartEdit.Sabado = c.Sabado;
            cartEdit.Domingo = c.Domingo;
            cartEdit.FechaCarga = DateTime.Now;

            ctx.SaveChanges();
        }

        //Trae una cartelera de la bd
        public Carteleras TraerCartelera(int id)
        {
            var car = ctx.Carteleras.Find(id);

            return car;
        } 

        //Borra una cartelera
        public void EliminarCartelera(int id)
        {
            var car = ctx.Carteleras.Find(id);
            ctx.Carteleras.Remove(car);
            ctx.SaveChanges();
        }

        //Trae una lista de carteleras para una sede
        public List<Carteleras> CartelerasSede(int idSede)
        {
            List<Carteleras> CartSedes = ctx.Carteleras.Where(c => c.IdSede == idSede).ToList();

            return CartSedes;
        }

        //Trae una cartelera por película, sede y version
        public Carteleras CarteleraPeliSedeYVersion(int IdPelicula, int IdSede, int IdVersion)
        {
            var Cartelera = ctx.Carteleras.Where(c => c.IdPelicula == IdPelicula &&
                   c.IdSede == IdSede && c.IdVersion == IdVersion).FirstOrDefault();

            return Cartelera;
        }

        //Trae una lista de carteleras
        public List<Carteleras> ListarCarteleras()
        {
            List<Carteleras> carteleras = ctx.Carteleras.ToList();

            return carteleras;
        }


    }
}
