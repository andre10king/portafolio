using proyectoandresbeta.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace proyectoandresbeta.Datos
{
    public class ArticuloAdmin
    {

        public async Task<IEnumerable<articulo>> Consultar()
        {
            using (sebastian_testEntities contexto = new sebastian_testEntities())
            {
                return await contexto.articulo.AsNoTracking().ToListAsync();
            }
               
        }
    }
}