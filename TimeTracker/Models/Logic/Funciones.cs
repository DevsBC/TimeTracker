using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Configuration;
using TimeTracker.Models.Class;
using TimeTracker.Models.Data;


namespace TimeTracker.Models.Logic
{
    public static class Funciones
    {
        public static List<int?> GetRolDeUsuario(int? usuarioId)
        {
            var db = new TemplateEntities1();
            List<int?> resultado = new List<int?>();

            var usuario = db.Usuarios.FirstOrDefault(x => x.UsuarioId == usuarioId);

            if (usuario != null)
            {
                var menus = (from r in db.Roles
                             join a in db.Accesos on r.RolId equals a.RolId
                             join m in db.Modulos on a.ModuloId equals m.ModuloId
                             where r.RolId == usuario.RolId
                             select new
                             {
                                 m.TagHTML, m.id
                             }).ToList();

                var listaMenuString = string.Empty;
                var listaMenusInt = new List<int?>();


                foreach(var item in menus)
                {
                    if (string.IsNullOrEmpty(listaMenuString)) {
                        listaMenuString = item.TagHTML;
                    } else
                    {
                        listaMenuString += "," + item.TagHTML;
                    }
                }

                HttpContext.Current.Session["menu"] = listaMenuString;
                return menus.Select(x => x.id).ToList();
            }

            return resultado;
        }

        public static int? GetIdDeUsuario(string nombreDeUsuario)
        {
            var db = new TemplateEntities1();

            var usuario = db.Usuarios.FirstOrDefault(x => x.NombreDeUsuario == nombreDeUsuario);
            if (usuario != null)
            {
                return usuario.UsuarioId;
            }

            return null;
        }

        public static Class.Roles GetRoles(int? rolId)
        {
            var roles = new Class.Roles();
            var db = new TemplateEntities1();
            var listaRoles = new List<Class.Roles>();

            var rolesdb = db.Roles.ToList();

            foreach( var item in rolesdb)
            {
                listaRoles.Add(new Class.Roles {
                    RolId = item.RolId,
                    Nombre = item.Nombre,
                    Activo = Convert.ToBoolean(item.Activo),

                });
            }

            var buscarRol = rolesdb.FirstOrDefault(x => x.RolId == rolId);
            if (buscarRol != null)
            {
                roles.Nombre = buscarRol.Nombre;
                roles.Activo = Convert.ToBoolean(buscarRol.Activo);
                roles.RolId = buscarRol.RolId;
            }
            roles.ListaDeRoles = listaRoles;

            return roles;
        }

        public static Class.Modulos GetModulos(int? moduloId)
        {
            var modulos = new Class.Modulos();
            var db = new TemplateEntities1();
            var listaModulos = new List<Class.Modulos>();

            var modulosdb = db.Modulos.ToList();

            foreach (var item in modulosdb)
            {
                listaModulos.Add(new Class.Modulos
                {
                    ModuloId = item.ModuloId,
                    TagHTML = item.TagHTML,
                    Nombre = item.Nombre,
                    Activo = Convert.ToBoolean(item.Activo),

                });
            }

            var buscarModulo = modulosdb.FirstOrDefault(x => x.ModuloId == moduloId);
            if (buscarModulo != null)
            {
                modulos.Nombre = buscarModulo.Nombre;
                modulos.TagHTML = buscarModulo.TagHTML;
                modulos.Activo = Convert.ToBoolean(buscarModulo.Activo);
                modulos.ModuloId = buscarModulo.ModuloId;
            }
            modulos.ListaDeModulos = listaModulos;

            return modulos;
        }

        public static Class.Usuarios GetUsuarios(int? usuarioId)
        {
            var usuarios = new Class.Usuarios();
            var db = new TemplateEntities1();
            var listaUsuarios = new List<Class.Usuarios>();

            var usuariosdb = db.Usuarios.ToList();

            foreach (var item in usuariosdb)
            {
                listaUsuarios.Add(new Class.Usuarios
                {
                    UsuarioId = item.UsuarioId,
                    Nombre = item.Nombre,
                    NombreDeUsuario = item.NombreDeUsuario,
                    ApellidoPaterno = item.ApellidoPaterno,
                    ApellidoMaterno = item.ApellidoMaterno,
                    Activo = Convert.ToBoolean(item.Activo),
                    NombreDelRol = GetNombreRol(item.RolId),
                    RolId = item.RolId
                }); ;
            }

            var buscarUsuario = usuariosdb.FirstOrDefault(x => x.UsuarioId == usuarioId);
            if (buscarUsuario != null)
            {
                usuarios.Nombre = buscarUsuario.Nombre;
                usuarios.NombreDeUsuario = buscarUsuario.NombreDeUsuario;
                usuarios.ApellidoPaterno = buscarUsuario.ApellidoPaterno;
                usuarios.ApellidoMaterno = buscarUsuario.ApellidoMaterno;
                usuarios.Activo = Convert.ToBoolean(buscarUsuario.Activo);
                usuarios.RolId = buscarUsuario.RolId;
            }
            usuarios.ListaDeUsuarios = listaUsuarios;
            usuarios.ListaDeRoles = GetListaRoles();
            return usuarios;
        }

        public static string GetNombreRol(int? rolId)
        {
            var db = new TemplateEntities1();
            var resultado = string.Empty;
            var rol = db.Roles.FirstOrDefault(x => x.RolId == rolId);
            if (rol != null)
            {
                return rol.Nombre;
            }
            return resultado;
        }

        public static List<SelectListItem> GetListaRoles()
        {
            var listaRoles = new List<SelectListItem>();
            var db = new TemplateEntities1();
            var roles = db.Roles.Where(x => x.Activo == true).ToList();
            foreach(var item in roles) {
                listaRoles.Add(new SelectListItem
                {
                    Text = item.Nombre,
                    Value = item.RolId.ToString()
                });
            }
            return listaRoles;
        }


        public static Class.Registros GetRegistros(int? registroId)
        {
            var registros = new Class.Registros();
            var db = new TemplateEntities1();
            var listaRegistros = new List<Class.Registros>();

            var registrosdb = db.Registros.ToList();

            foreach (var item in registrosdb)
            {
                listaRegistros.Add(new Class.Registros
                {
                    RegistroId = item.RegistroId,
                    TareaId = item.TareaId,
                    UsuarioId = item.UsuarioId,
                    EtiquetaId = item.EtiquetaId,
                    ProyectoId = item.ProyectoId
                }); ;
            }

            var buscarRegistro = registrosdb.FirstOrDefault(x => x.RegistroId == registroId);
            if (buscarRegistro != null)
            {
                registros.RegistroId = buscarRegistro.RegistroId;
                registros.TareaId = buscarRegistro.TareaId;
                registros.UsuarioId = buscarRegistro.UsuarioId;
                registros.EtiquetaId = buscarRegistro.EtiquetaId;
                registros.ProyectoId = buscarRegistro.ProyectoId;
            }
            registros.ListaDeRegistros = ActualizarRegistros.GetRegistrosDeUsuario(1016);
            registros.ListaDeEtiquetas = GetListaDeEtiquetas();
            registros.ListaDeProyectos = GetListaDeProyectos();
            registros.ListaDeTareas = GetListaDeTareas(registros.TareaId);
            return registros;
        }

        public static List<SelectListItem> GetListaDeEtiquetas()
        {
            var listaEtiquetas = new List<SelectListItem>();
            var db = new TemplateEntities1();
            var etiquetas = db.Etiquetas.ToList();
            foreach (var item in etiquetas)
            {
                listaEtiquetas.Add(new SelectListItem
                {
                    Text = item.Nombre,
                    Value = item.EtiquetaId.ToString()
                });
            }
            return listaEtiquetas;
        }

        public static List<SelectListItem> GetListaDeProyectos()
        {
            var listaProyectos = new List<SelectListItem>();
            var db = new TemplateEntities1();
            var proyectos = db.Proyectos.ToList();
            foreach (var item in proyectos)
            {
                listaProyectos.Add(new SelectListItem
                {
                    Text = item.Nombre,
                    Value = item.ProyectoId.ToString()
                });
            }
            return listaProyectos;
        }

        public static List<Class.Tareas> GetListaDeTareas(int? tareaId)
        {
            var listaTareas = new List<Class.Tareas>();
            var db = new TemplateEntities1();
            var tareas = db.Tareas.Where(x => x.TareaId == tareaId).ToList();
            if (tareas != null)
            {
                foreach (var item in tareas)
                {
                    listaTareas.Add(new Class.Tareas
                    {
                        TareaId = item.TareaId,
                        Descripcion = item.Descripcion,
                        HoraInicio = item.HoraInicio,
                        HoraFinal = item.HoraFinal,
                        Facturable = item.Facturable
                    });
                }
            }
            return listaTareas;
        }

        public static bool? GetLoginUsuario(Login model)
        {
            var db = new TemplateEntities1();
            var usuario = db.Usuarios.FirstOrDefault(x => x.NombreDeUsuario == model.Usuario);
            if (usuario != null)
            {
                CryptographyManager crypto = new CryptographyManager();
                var response = crypto.VerifyHash(model.Clave, "SHA512", usuario.Password);
                return response;
            }
            return false;
        }


        public static Class.ListaDeAccesos GetListaAccesos(int? rolId)
        {
            var db = new TemplateEntities1();
            var accesos = new Class.ListaDeAccesos();
            var listaRoles = new List<Class.Roles>();
            var listaacceso = new List<Class.Accesos>();
            var roles = db.Roles.Where(x => x.Activo == true).ToList();
            foreach (var item in roles)
            {
                listaRoles.Add(new Class.Roles
                {
                    RolId = item.RolId,
                    Nombre = item.Nombre
                });
            }
            var rol = db.Roles.FirstOrDefault(x => x.RolId == rolId);
            if (rol != null)
            {
                accesos.NombreRol = rol.Nombre;
                accesos.RolId = rol.RolId;
                accesos.Activo = Convert.ToBoolean(rol.Activo);

                var listaAccessos = (from a in db.Accesos
                                     where a.RolId == rolId
                                    select new
                                     {
                                         a.ModuloId,
                                     }).ToList();

                var modulo = db.Modulos.Where(x => x.Activo == true).ToList();  
                foreach (var item in modulo)
                {
                    listaacceso.Add(new Class.Accesos
                    {
                        NombreDeModulo = item.Nombre,
                        ModuloId = item.ModuloId,
                        Checked = listaAccessos.FirstOrDefault(x => x.ModuloId == item.ModuloId) != null ? "checked" : string.Empty
                    });
                }           
            } 
            else
            {
                var modulo = db.Modulos.Where(x => x.Activo == true).ToList();
                foreach (var item in modulo)
                {
                    listaacceso.Add(new Class.Accesos
                    {
                        NombreDeModulo = item.Nombre,
                        ModuloId = item.ModuloId,
                        Checked = string.Empty
                    });
                }
            }
            accesos.LAccesos = listaacceso;
            accesos.LRoles = listaRoles;
            return accesos;
        }

    }
}