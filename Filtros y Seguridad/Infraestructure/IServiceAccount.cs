using Filtros_y_Seguridad.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Filtros_y_Seguridad.Infraestructure
{
    public interface IServiceAccount
    {
        Usuario Login(Usuario usuario);
    }
}
