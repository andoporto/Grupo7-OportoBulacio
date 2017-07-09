using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocioDatos.Servicios
{
    public class DalDocumentos
    {
        Context ctx = new Context();

        public List<TiposDocumentos> TraerTiposDocumentos()
        {
            var doc = ctx.TiposDocumentos.ToList();

            return doc;
        }
    }
}
