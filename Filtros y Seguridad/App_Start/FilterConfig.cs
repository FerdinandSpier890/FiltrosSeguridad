using System.Web;
using System.Web.Mvc;

namespace Filtros_y_Seguridad
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
