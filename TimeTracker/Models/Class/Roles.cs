using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TimeTracker.Models.Class
{
    public class Roles
    {
        public int? RolId { get; set; }

        public string Nombre { get; set; }

        public bool Activo { get; set; }

        public int CreadoPor { get; set; }

        public DateTime? CreadoEn { get; set; }

        public int ModificadoPor { get; set; }

        public DateTime? ModificadoEn { get; set; }

        public List<Roles> ListaDeRoles { get; set; }
    }
}