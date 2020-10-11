using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TimeTracker.Models.Class
{
    public class Tareas
    {
        public int? TareaId { get; set; }
        public int? HoraInicio { get; set; }
        public int? HoraFinal { get; set; }
#pragma warning disable CS8632 // La anotación para tipos de referencia que aceptan valores NULL solo debe usarse en el código dentro de un contexto de anotaciones "#nullable".
        public string Descripcion { get; set; }
#pragma warning restore CS8632 // La anotación para tipos de referencia que aceptan valores NULL solo debe usarse en el código dentro de un contexto de anotaciones "#nullable".
        public bool? Facturable { get; set; }
    }
}