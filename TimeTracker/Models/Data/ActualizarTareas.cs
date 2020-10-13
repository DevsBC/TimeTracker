using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TimeTracker.Models.Logic;

namespace TimeTracker.Models.Data
{
    public class ActualizarTareas
    {
        public static Class.Registros Actualizar(Class.Registros model)
        {
            var db = new TemplateEntities1();
            if (model.TareaId == null)
            {
                var nuevaTarea = db.Tareas.Create();
                nuevaTarea.HoraInicio = model.HoraInicio;
                nuevaTarea.HoraFinal = model.HoraFinal;
                nuevaTarea.Descripcion = model.Descripcion;
                nuevaTarea.Facturable = model.Facturable;
                db.Tareas.Add(nuevaTarea);
                db.SaveChanges();
                model.TareaId = nuevaTarea.TareaId;
            }
            else
            {
                var tareaActualizada = db.Tareas.First(x => x.TareaId == model.TareaId);
                tareaActualizada.HoraInicio = model.HoraInicio;
                tareaActualizada.HoraFinal = model.HoraFinal;
                tareaActualizada.Descripcion = model.Descripcion;
                tareaActualizada.Facturable = model.Facturable;
                db.SaveChanges();
            }

            return model;
        }

        public static bool Eliminar(int tareaId)
        {
            var db = new TemplateEntities1();
            using (var ctx = new TemplateEntities1())
            {
                var usuario = db.Tareas.FirstOrDefault(x => x.TareaId == tareaId);
                if (usuario != null)
                {
                    var a = new Tareas() { TareaId = tareaId };
                    ctx.Tareas.Attach(a);
                    ctx.Tareas.Remove(a);
                    ctx.SaveChanges();
                    return true;
                }
            }
            return false;

        }
    }
}