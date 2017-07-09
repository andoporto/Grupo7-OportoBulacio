using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cinemania.Models
{
    

    public class ListarCalificacion
    {
        public int IdCalificacion { get; set; }
        public string Nombre { get; set; }
        public SelectList DatosSucursal { get; set; }

    }

    public class Listar
    {
        public IEnumerable<ListarCalificacion> GetCalificaciones()
        {

            string connection = System.Configuration.ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            var calificaciones = new List<ListarCalificacion>();
            var conObj = new SqlConnection(connection);
            conObj.Open();
            var command = new SqlCommand("Select IdCalificacion, Nombre from Calificaciones ORDER BY Nombre", conObj);

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                calificaciones.Add(new ListarCalificacion { Nombre = Convert.ToString(reader["NombreSucursal"]), IdCalificacion = Convert.ToInt32(reader["IdCalificacion"]) });
            }

            return calificaciones;

        }


    }
}