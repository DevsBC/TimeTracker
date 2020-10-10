using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TimeTracker.Models.Class
{
    public class Tareas
    {
        public int TareaId { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFinal { get; set; }
        public string Descripcion { get; set; }
        public bool Facturable { get; set; }
    }
}