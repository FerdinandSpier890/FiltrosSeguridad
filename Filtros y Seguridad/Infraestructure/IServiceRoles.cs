using Filtros_y_Seguridad.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filtros_y_Seguridad.Infraestructure
{
    public interface IServiceRoles
    {
        List<Models.Role> ListarRol();

        bool CrearRoles(Models.Role role);

        bool EliminarRoles(int id);
    }
}
