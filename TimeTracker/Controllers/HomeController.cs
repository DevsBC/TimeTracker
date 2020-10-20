using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TimeTracker.Models.Class;
using TimeTracker.Models.Logic;
using TimeTracker.Models.Data;
namespace TimeTracker.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            if (Funciones.GetRolDeUsuario(Funciones.GetIdDeUsuario(User.Identity.Name)).Contains(0))
            {
                return View();
            } 
            else
            {
                return Redirect("../Home/Restringido");
            }
        }

        public ActionResult Restringido()
        {
            return View();
        }

        [Authorize]

        [HttpGet]
        public ActionResult Tracker(int? registroId)
        {
            var model = Funciones.GetRegistros(registroId);
            return View(model);
        }

        [HttpPost]
        public string Tracker(Registros registro)
        {
            var tarea = ActualizarTareas.Actualizar(registro);
            var model = ActualizarRegistros.Actualizar(tarea);
            return model;
        }

        [HttpPost]
        public string EliminarRegistro(int registroId)
        {
            ActualizarRegistros.Eliminar(registroId);
            var model = Funciones.GetRegistros(registroId);
            return model.ListaDeRegistros;
        }

        [HttpPost]
        public string EditarRegistro(int registroId, string descripcion)
        {
            ActualizarRegistros.Editar(registroId, descripcion);
            var model = Funciones.GetRegistros(registroId);
            return model.ListaDeRegistros;
        }


        [Authorize]
        [HttpGet]
        public ActionResult Roles(int? rolId)
        {
           
            if (Funciones.GetRolDeUsuario(Funciones.GetIdDeUsuario(User.Identity.Name)).Contains(2))
            {
                var model = Funciones.GetRoles(rolId);
                return View(model);
            }
             else        
            {
                return Redirect("../Home/Restringido");
            }
        }

        [Authorize]
        [HttpPost]
        public ActionResult Roles(Roles model)
        {
            model = ActualizarRoles.Actualizar(model);
            return View(model);
        }

        [Authorize]
        [HttpGet]
        public ActionResult Modulos(int? moduloId)
        {
            if (Funciones.GetRolDeUsuario(Funciones.GetIdDeUsuario(User.Identity.Name)).Contains(4))
            {
                var model = Funciones.GetModulos(moduloId);
                return View(model);
            }
            else
            {
                return Redirect("../Home/Restringido");
            }

        }

        [Authorize]
        [HttpPost]
        public ActionResult Modulos(Modulos model)
        {
            model = ActualizarModulos.Actualizar(model);
            return View(model);
        }

        [Authorize]
        [HttpGet]
        public ActionResult Usuarios(int? usuarioId)
        {
            Funciones.GetRolDeUsuario(Funciones.GetIdDeUsuario(User.Identity.Name));
            var model = Funciones.GetUsuarios(usuarioId);
            return View(model);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Usuarios(Usuarios model)
        {
            if (Funciones.GetRolDeUsuario(Funciones.GetIdDeUsuario(User.Identity.Name)).Contains(3))
            {
                model = ActualizarUsuarios.Actualizar(model);
                return View(model);
            }
            else
            {
                return Redirect("../Home/Restringido");
            }

        }

        [Authorize]
        public ActionResult EliminarUsuarios(int? usuarioId)
        {
            Funciones.GetRolDeUsuario(Funciones.GetIdDeUsuario(User.Identity.Name));
            ActualizarUsuarios.Eliminar(Convert.ToInt32(usuarioId));
            return Redirect("../Home/Usuarios?usuarioId=" + usuarioId);
        }

        [Authorize]
        [HttpGet]
        public ActionResult Accesos(int? rolId)
        {
            if (Funciones.GetRolDeUsuario(Funciones.GetIdDeUsuario(User.Identity.Name)).Contains(1))
            {
                var model = Funciones.GetListaAccesos(rolId);
                return View(model);
            }
            else
            {
                return Redirect("../Home/Restringido");
            }
        }

        [Authorize]
        [HttpPost]
        public ActionResult Accesos(ListaDeAccesos model)
        {

            model = ActualizarAccesos.Actualizar(model);
            Funciones.GetRolDeUsuario(Funciones.GetIdDeUsuario(User.Identity.Name));
            return View(model);
            
            
        }
    }
}