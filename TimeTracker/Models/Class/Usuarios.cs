using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TimeTracker.Models.Class
{
    public class Usuarios
    {
        public int? UsuarioId { get; set; }

        public int? RolId { get; set; }

        public string Nombre { get; set; }

        public string NombreDeUsuario { get; set; }

        public string ApellidoPaterno { get; set; }

        public string ApellidoMaterno { get; set; }

        public string Password { get; set; }

        public bool Activo { get; set; }

        public int CreadoPor { get; set; }

        public DateTime? CreadoEn { get; set; }

        public int ModificadoPor { get; set; }

        public DateTime? ModificadoEn { get; set; }
        public List<Usuarios> ListaDeUsuarios { get; set; }

        public List<SelectListItem> ListaDeRoles { get; set; }

        public string NombreDelRol { get; set; }

    }
}