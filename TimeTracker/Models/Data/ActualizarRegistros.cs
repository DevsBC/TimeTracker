using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TimeTracker.Models.Logic;

namespace TimeTracker.Models.Data
{
    public class ActualizarRegistros
    {
        public static List<Class.Registros> Actualizar(Class.Registros model)
        {
            var db = new TimeTrackerEntities1();
            if (model.RegistroId == null)
            {
                var nuevoRegistro = db.Registros.Create();
                nuevoRegistro.ProyectoId = model.ProyectoId;
                nuevoRegistro.EtiquetaId = model.EtiquetaId;
                nuevoRegistro.TareaId = Convert.ToInt32(model.TareaId);
                nuevoRegistro.UsuarioId = model.UsuarioId;
                db.Registros.Add(nuevoRegistro);
                db.SaveChanges();
            }
            else
            {
                var registroActualizado = db.Registros.First(x => x.RegistroId == model.RegistroId);
                registroActualizado.ProyectoId = model.ProyectoId;
                registroActualizado.EtiquetaId = model.EtiquetaId;
                registroActualizado.ProyectoId = model.ProyectoId;
                registroActualizado.UsuarioId = model.UsuarioId;
                db.SaveChanges();
            }
            return Funciones.GetRegistros(model.RegistroId).ListaDeRegistros;
        }
    }
}