using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocioDatos.Servicios
{
    public class DalPeliculas
    {
        Context ctx = new Context();

        //Nueva película
        public void AgregarPeliculas(Peliculas p)
        {
            p.FechaCarga = DateTime.Now;
            ctx.Peliculas.Add(p);
            ctx.SaveChanges();
        }

        //Trae una determinada película de la db
        public Peliculas TraerPelicula(int? id)
        {
            return ctx.Peliculas.Find(id);
        }

        //Editar película
        public void EditarPelicula(Peliculas p, int id)
        {
            var peli = new Peliculas { IdPelicula = id };
            ctx.Peliculas.Attach(peli);

            peli.Nombre = p.Nombre;
            peli.Descripcion = p.Descripcion;
            peli.IdCalificacion = p.IdCalificacion;
            peli.IdGenero = p.IdGenero;
            peli.Imagen = p.Imagen;
            peli.Duracion = p.Duracion;

            ctx.SaveChanges();
        }

        //Borrar pelicula
        public void EliminarPelicula(int id)
        {
            var peli = ctx.Peliculas.Find(id);
            ctx.Peliculas.Remove(peli);
            ctx.SaveChanges();
        }

        //Traer la lista de generos de la db
        public List<Generos> TraerGeneros()
        {
            List<Generos> generos = ctx.Generos.ToList();

            return generos;
        }

        //Traer la lista de calificaciones de la db
        public List<Calificaciones> TraerCalificaciones()
        {
            List<Calificaciones> calificaciones = ctx.Calificaciones.ToList();

            return calificaciones;
        }

        //Traer la lista de versiones de la db
        public List<Versiones> TraerVersiones()
        {
            List<Versiones> versiones = ctx.Versiones.ToList();

            return versiones;
        }

        //Traer la lista de películas
        public List<Peliculas> ListarPeliculas()
        {
            List<Peliculas> pelis = ctx.Peliculas.ToList();

            return pelis;
        }

    }
}
