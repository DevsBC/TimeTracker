﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TimeTracker.Models.Logic;

namespace TimeTracker.Models.Data
{
    public class ActualizarAccesos
    {
        public static Class.ListaDeAccesos Actualizar(Class.ListaDeAccesos model)
        {
            var db = new TemplateEntities1();
            // var accesos = db.Accesos.Where(x => x.RolId == model.RolId);
            if (model.RolId == null)
            {

                var nuevoRol = db.Roles.Create();
                nuevoRol.Activo = model.Activo;
                nuevoRol.Nombre = model.NombreRol;
                db.Roles.Add(nuevoRol);
                db.SaveChanges();

                if (!string.IsNullOrEmpty(model.Modulos))
                {
                    var modulos = model.Modulos.Split(',').Select(n => n).ToList();
                    foreach (var item in modulos)
                    {
                        var nuevoAcceso = db.Accesos.Create();
                        nuevoAcceso.RolId = nuevoRol.RolId;
                        nuevoAcceso.ModuloId = Convert.ToInt32(item);
                        db.Accesos.Add(nuevoAcceso);
                        db.SaveChanges();
                    }

                }

            }
            else
            {
                var editarRol = db.Roles.First(x => x.RolId == model.RolId);
                editarRol.Activo = model.Activo;
                editarRol.Nombre = model.NombreRol;
                db.SaveChanges();

                using (var ctx = new TemplateEntities1())
                {
                    var listaAccesos = db.Accesos.Where(x => x.RolId == model.RolId).ToList();
                    if (listaAccesos.Any())
                    {

                        foreach (var item in listaAccesos)
                        {
                            var id = item.AccesoId;
                            var a = new Accesos() { AccesoId = id };
                            ctx.Accesos.Attach(a);
                            ctx.Accesos.Remove(a);
                            ctx.SaveChanges();

                        }
                    }                    
                }

                if (!string.IsNullOrEmpty(model.Modulos))
                {
                    var modulos = model.Modulos.Split(',').Select(n => n).ToList();
                    foreach (var item in modulos)
                    {
                        var nuevoAcceso = db.Accesos.Create();
                        nuevoAcceso.RolId = model.RolId;
                        nuevoAcceso.ModuloId = Convert.ToInt32(item);
                        db.Accesos.Add(nuevoAcceso);
                        db.SaveChanges();
                    }

                }


            }
            return Funciones.GetListaAccesos(model.RolId);
        }

    }
}