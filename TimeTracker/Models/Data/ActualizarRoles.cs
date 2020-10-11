using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TimeTracker.Models.Logic;
namespace TimeTracker.Models.Data
{
    public static class ActualizarRoles
    { 
        public static Class.Roles Actualizar(Class.Roles model)
        {
            var db = new TimeTrackerEntities1();
            if (model.RolId == null)
            {
                var rolRecuperado = db.Roles.FirstOrDefault(x => x.Nombre == model.Nombre);
                if (rolRecuperado == null)
                {
                    var nuevoRol = db.Roles.Create();
                    nuevoRol.Nombre = model.Nombre;
                    nuevoRol.Activo = model.Activo;

                    db.Roles.Add(nuevoRol);
                    db.SaveChanges();
                    model.RolId = nuevoRol.RolId;

                }
                
            } 
            else
            {
                var rolActualizado = db.Roles.First(x => x.RolId == model.RolId);
                rolActualizado.Nombre = model.Nombre;
                rolActualizado.Activo = model.Activo;
                db.SaveChanges();
            }
            return Funciones.GetRoles(model.RolId);
        }

    }
}