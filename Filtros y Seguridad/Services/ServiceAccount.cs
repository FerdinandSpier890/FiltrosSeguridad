using Filtros_y_Seguridad.Infraestructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Data.Entity;
using Filtros_y_Seguridad.Models;

namespace Filtros_y_Seguridad.Services
{
    public class ServiceAccount : IServiceAccount
    {
        public Usuario Login(Usuario usuario)
        {
            Usuario user = null;
            try
            {
                using(var contexto = new FiltroSeguridadEntities1())
                {
                    user = contexto.
                        Usuario.Include(p => p.Role).
                        FirstOrDefault(p => p.NombreUsuario ==
                        usuario.NombreUsuario && p.Password == usuario.Password);
                }
            }
            catch (Exception ex)
            {
                String mensajeErr = ex.Message;
            }
            return user;
        }
    }
}