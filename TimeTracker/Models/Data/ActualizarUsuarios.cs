using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using TimeTracker.Models.Logic;

namespace TimeTracker.Models.Data
{
    public class ActualizarUsuarios
    {
        public static Class.Usuarios Actualizar(Class.Usuarios model)
        {
            var db = new TimeTrackerEntities1();
            if (model.UsuarioId == null)
            {
                var usuarioRecuperado = db.Usuarios.FirstOrDefault(x => x.Nombre == model.Nombre);
                if (usuarioRecuperado == null)
                {
                    var siguienteUsuario = 1;
                    if(db.Usuarios.Any()) 
                        siguienteUsuario = db.Usuarios.Max(x => x.UsuarioId);

                    
                    var nuevoUsuario = db.Usuarios.Create();
                    nuevoUsuario.Nombre = model.Nombre;
                    nuevoUsuario.NombreDeUsuario = "@" + model.Nombre.Replace(" ", string.Empty).ToLower() + (siguienteUsuario + 1);
                    nuevoUsuario.Password = CryptographyManager.ComputeHash("tracker?", "SHA512", null);
                    nuevoUsuario.ApellidoPaterno = model.ApellidoPaterno;
                    nuevoUsuario.ApellidoMaterno = model.ApellidoMaterno;
                    nuevoUsuario.Activo = model.Activo;
                    nuevoUsuario.RolId = model.RolId;

                    db.Usuarios.Add(nuevoUsuario);
                    db.SaveChanges();
                    model.UsuarioId = nuevoUsuario.UsuarioId;
                } else
                {
                    var usuarioEncontrado = db.Usuarios.Create();
                    usuarioEncontrado.Nombre = model.Nombre;
                    usuarioEncontrado.NombreDeUsuario = model.NombreDeUsuario;
                    usuarioEncontrado.ApellidoPaterno = model.ApellidoPaterno;
                    usuarioEncontrado.ApellidoMaterno = model.ApellidoMaterno;
                    usuarioEncontrado.Activo = model.Activo;
                    usuarioEncontrado.RolId = model.RolId;

                    db.Usuarios.AddOrUpdate(usuarioEncontrado);
                    db.SaveChanges();
                    model.UsuarioId = usuarioEncontrado.UsuarioId;

                }

            }
            else
            {
                var usuarioActualizado = db.Usuarios.First(x => x.UsuarioId == model.UsuarioId);
                usuarioActualizado.Nombre = model.Nombre;
                usuarioActualizado.NombreDeUsuario = model.NombreDeUsuario;
                usuarioActualizado.ApellidoPaterno = model.ApellidoPaterno;
                usuarioActualizado.ApellidoMaterno = model.ApellidoMaterno;
                usuarioActualizado.Activo = model.Activo;
                usuarioActualizado.RolId = model.RolId;

                db.SaveChanges();
            }
            return Funciones.GetUsuarios(model.UsuarioId);
        }

        public static bool Eliminar(int usuarioId)
        {
            var db = new TimeTrackerEntities1();
            using(var ctx = new TimeTrackerEntities1())
            {
                var usuario = db.Usuarios.FirstOrDefault(x => x.UsuarioId == usuarioId);
                if (usuario != null)
                {
                    var a = new Usuarios() { UsuarioId = usuarioId };
                    ctx.Usuarios.Attach(a);
                    ctx.Usuarios.Remove(a);
                    ctx.SaveChanges();
                    return true;
                }
            }
            return false;
        }
    }
}