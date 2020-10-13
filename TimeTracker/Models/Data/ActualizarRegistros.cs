using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TimeTracker.Models.Logic;

namespace TimeTracker.Models.Data
{
    public class ActualizarRegistros
    {
        public static string Actualizar(Class.Registros model)
        {
            var db = new TemplateEntities1();
            var usuarioId = 0;
            if (model.RegistroId == null)
            {
                var nuevoRegistro = db.Registros.Create();
                nuevoRegistro.ProyectoId = model.ProyectoId;
                nuevoRegistro.EtiquetaId = model.EtiquetaId;
                nuevoRegistro.TareaId = Convert.ToInt32(model.TareaId);
                nuevoRegistro.UsuarioId = model.UsuarioId;
                usuarioId = model.UsuarioId;
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
                usuarioId = model.UsuarioId;
                db.SaveChanges();
            }
            string listaRegistros = GetRegistrosDeUsuario(usuarioId);
            return listaRegistros;
        }

        public static string GetRegistrosDeUsuario(int usuarioId)
        {
            using (var ctx = new TemplateEntities1())
            {
                var query = from r in ctx.Registros
                            join t in ctx.Tareas on r.TareaId equals t.TareaId
                            join e in ctx.Etiquetas on r.EtiquetaId equals e.EtiquetaId
                            join p in ctx.Proyectos on r.ProyectoId equals p.ProyectoId
                            where r.UsuarioId == usuarioId
                            orderby r.RegistroId descending
                            select new Class.Registros
                            {
                                TareaId = r.TareaId,
                                NombreDeEtiqueta = e.Nombre,
                                NombreDeProyecto = p.Nombre,
                                Descripcion = t.Descripcion,
                                HoraInicio = t.HoraInicio,
                                HoraFinal = t.HoraFinal,
                                Facturable = t.Facturable.Value,
                                RegistroId = r.RegistroId
                            };
                return Newtonsoft.Json.JsonConvert.SerializeObject(query.ToList());
            };
        }

        public static bool Eliminar(int registroId)
        {
            var db = new TemplateEntities1();
            var registroHaSidoBorrado = false;
            var tareaHaSidoBorrada = false;
            using (var ctx = new TemplateEntities1())
            {
                var registro = db.Registros.FirstOrDefault(x => x.RegistroId == registroId);
                if (registro != null)
                {
                    var tareaId = registro.TareaId;
                    var a = new Registros() { RegistroId = registroId };
                    ctx.Registros.Attach(a);
                    ctx.Registros.Remove(a);
                    ctx.SaveChanges();
                    registroHaSidoBorrado = true;

                    var tarea = db.Tareas.FirstOrDefault(x => x.TareaId == tareaId);
                    if (tarea != null)
                    {
                        var b = new Tareas() { TareaId = tareaId };
                        ctx.Tareas.Attach(b);
                        ctx.Tareas.Remove(b);
                        ctx.SaveChanges();
                        tareaHaSidoBorrada = true;
                    }
                }          
                return (registroHaSidoBorrado && tareaHaSidoBorrada);
            }
        }
    }
}