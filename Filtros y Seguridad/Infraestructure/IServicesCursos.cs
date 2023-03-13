using Filtros_y_Seguridad.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Filtros_y_Seguridad.Models.FiltroSeguridadEntities1;

namespace Filtros_y_Seguridad.Infraestructure
{
    public interface IServicesCursos
    {
        List<Models.Cursos> Get();
    }
}
