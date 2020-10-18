using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TimeTracker.Models.Class
{
    public class Accesos
    {
        public int AccesoId { get; set; }
        public int RolId { get; set; }
        public int ModuloId { get; set; }
        public int CreadoPor { get; set; }
        public string NombreDeModulo { get; set; }
        public string Checked { get; set; }
        public DateTime? CreadoEn { get; set; }
        public int ModificadoPor { get; set; }
        public DateTime? ModificadoEn { get; set; }
    }

    public class ListaDeAccesos
    {
        public int? RolId { get; set; }
        public string NombreRol { get; set; }
        public string Modulos { get; set; }

        public bool Activo { get; set; }
        public List<Class.Accesos> LAccesos { get; set; }
        public List<Class.Roles> LRoles { get; set; }

    }
}