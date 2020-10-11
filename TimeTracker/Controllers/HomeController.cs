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
            return Newtonsoft.Json.JsonConvert.SerializeObject(model);
        }



        [Authorize]
        [HttpGet]
        public ActionResult Roles(int? rolId)
        {
           var model = Funciones.GetRoles(rolId);
           return View(model);
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
            var model = Funciones.GetModulos(moduloId);
            return View(model); 
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
            var model = Funciones.GetUsuarios(usuarioId);
            return View(model);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Usuarios(Usuarios model)
        {
            model = ActualizarUsuarios.Actualizar(model);
            return View(model);
        }

        [Authorize]
        public ActionResult EliminarUsuarios(int? usuarioId)
        {
            ActualizarUsuarios.Eliminar(Convert.ToInt32(usuarioId));
            return Redirect("../Home/Usuarios?usuarioId=" + usuarioId);
        }

        [Authorize]
        public ActionResult Accesos() => View();
    }
}