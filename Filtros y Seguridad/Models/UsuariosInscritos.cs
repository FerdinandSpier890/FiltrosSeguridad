//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Filtros_y_Seguridad.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class UsuariosInscritos
    {
        public int Id { get; set; }
        public int PersonaId { get; set; }
        public int CursosId { get; set; }
    
        public virtual Cursos Cursos { get; set; }
        public virtual Persona Persona { get; set; }
    }
}
