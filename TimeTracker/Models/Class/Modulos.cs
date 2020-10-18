using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TimeTracker.Models.Class
{
    public class Modulos
    {
        public int? ModuloId { set; get; }
        public int? RolId { set; get; }

        public string Nombre { set; get; }

        public string TagHTML { set; get; }

        public bool Activo { set; get; }

        public int CreadoPor { get; set; }

        public DateTime? CreadoEn { get; set; }

        public int ModificadoPor { get; set; }

        public DateTime? ModificadoEn { get; set; }

        public List<Modulos> ListaDeModulos { get; set; }

    }
}