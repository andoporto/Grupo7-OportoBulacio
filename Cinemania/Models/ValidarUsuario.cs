using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Collections;
using CapaNegocioDatos;

namespace Cinemania.Models
{
    public class ValidarUsuario
    {
        public static Usuarios Validar (FormCollection login)
        {
            Context ctx = new Context();

            var nombreUsuario = login["Email"].ToString();
            var Pass = login["PassUsuario"].ToString();

            var user = ctx.Usuarios.Where(us => us.NombreUsuario == nombreUsuario && 
            us.Password == Pass).FirstOrDefault();

            return (user);
        }
    }
}

