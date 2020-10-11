using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TimeTracker.Models.Logic;

namespace TimeTracker.Models.Data
{
    public static class ActualizarModulos
    {
        public static Class.Modulos Actualizar(Class.Modulos model)
        {
            var db = new TimeTrackerEntities1();
            if (model.ModuloId == null)
            {
                var moduloRecuperado = db.Modulos.FirstOrDefault(x => x.Nombre == model.Nombre);
                if (moduloRecuperado == null)
                {
                    var nuevoModelo = db.Modulos.Create();
                    nuevoModelo.Nombre = model.Nombre;
                    nuevoModelo.TagHTML = model.TagHTML;
                    nuevoModelo.Activo = model.Activo;

                    db.Modulos.Add(nuevoModelo);
                    db.SaveChanges();
                    model.ModuloId = nuevoModelo.ModuloId;

                }

            }
            else
            {
                var modeloActualizado = db.Modulos.First(x => x.ModuloId == model.ModuloId);
                modeloActualizado.Nombre = model.Nombre;
                modeloActualizado.TagHTML = model.TagHTML;
                modeloActualizado.Activo = model.Activo;
                db.SaveChanges();
            }
            return Funciones.GetModulos(model.ModuloId);
        }

    }

}