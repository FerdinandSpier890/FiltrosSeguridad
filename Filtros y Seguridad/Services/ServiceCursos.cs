using Filtros_y_Seguridad.Infraestructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Filtros_y_Seguridad.Models;

namespace Filtros_y_Seguridad.Services
{
    public class ServiceCursos : IServicesCursos
    {
        public List<Models.Cursos> Get()
        {
            List<Models.Cursos> cursos = new List<Models.Cursos>();
            try
            {
                using (var conexion = new FiltroSeguridadEntities1())
                {
                    cursos = conexion.Cursos.Include(p => p.Categorias).
                        Include(p => p.Status).Include(p => p.Persona).
                        Where(p => p.StatusId == 1).ToList();
                }
            }
            catch (Exception ex)
            {
                string mensajes = ex.Message;
            }
            return cursos;
        }

    }
}