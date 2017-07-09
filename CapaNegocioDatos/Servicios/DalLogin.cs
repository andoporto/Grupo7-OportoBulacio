using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocioDatos.Servicios
{
    public class DalLogin
    {
        Context ctx = new Context();

        public Usuarios ValidarLog(string nombreUsuario, string Pass)
        {
            var user = ctx.Usuarios.Where(us => us.NombreUsuario == nombreUsuario &&
            us.Password == Pass).FirstOrDefault();

            return user;
        }
    }
}
