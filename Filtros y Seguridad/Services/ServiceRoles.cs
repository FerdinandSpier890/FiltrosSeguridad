using Filtros_y_Seguridad.Infraestructure;
using Filtros_y_Seguridad.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Filtros_y_Seguridad.Services
{
    public class ServiceRoles : IServiceRoles
    {
        public List<Models.Role> ListarRol()
        {
            List<Models.Role> rolesList = new List<Models.Role>();
            try
            {
                using(var conexion = new FiltroSeguridadEntities1())
                {
                    rolesList = conexion.Role.ToList();
                }
            }
            catch(Exception ex)
            {
                string mensajes = ex.Message;
            }
            return rolesList;
        }

        public bool CrearRoles(Models.Role role)
        {
            bool respuesta = false;
            try
            {
                using (var conexion = new FiltroSeguridadEntities1())
                {
                    conexion.Role.Add(role);
                    respuesta = true;
                    return respuesta;
                }
            } 
            catch(Exception ex) 
            {
                string mensajes = ex.Message;
                return respuesta;
            }
        }

        public bool EliminarRoles(int id)
        {
            bool respuesta = false;
            try
            {
                using (var conexion = new FiltroSeguridadEntities1())
                {
                    var rol = conexion.Role.Where(p => p.Id == id).FirstOrDefault();
                    conexion.Role.Remove(rol);
                    respuesta = true;
                    return respuesta;
                }
            }
            catch (Exception ex)
            {
                string mensajes = ex.Message;
                return respuesta;
            }
        }
    }
}