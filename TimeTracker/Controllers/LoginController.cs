using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TimeTracker.Models.Class;
using TimeTracker.Models.Logic;
using System.Web.Security;

namespace TimeTracker.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            var model = new Login();
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(Login model)
        {
            var response = Funciones.GetLoginUsuario(model);
            if (response == true)
            {
                FormsAuthentication.SetAuthCookie(model.Usuario, false);
                return Redirect("~/Home/Index");
            }
            model.Error = "Usuario o Clave incorrectos";
            return View(model);
        }
    }
}