using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TimeTracker.Models.Class;

namespace TimeTracker.Models.Class
{
    public class Registros
    {
        public int RegistroId { get; set; }
        public int TareaId { get; set; }
        public int UsuarioId { get; set; }
        public int EtiquetaId { get; set; }
        public int ProyectoId { get; set; }
        public List<SelectListItem> ListaDeProyectos { get; set; }
        public List<SelectListItem> ListaDeEtiquetas { get; set; }
        public List<Registros> ListaDeRegistros { get; set; }
        public List<Tareas> ListaDeTareas { get; set; }
        public string NombreDeProyecto { get; set; }
        public string NombreDeEtiqueta { get; set; }
        public string DescripcionTarea { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFinal { get; set; }
        public bool Facturable { get; set; }



    }
}