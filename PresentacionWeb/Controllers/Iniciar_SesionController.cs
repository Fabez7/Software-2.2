using Aplicacion;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PresentacionWeb.Controllers
{
    public class Iniciar_SesionController : Controller
    {
        
        public ActionResult Login()
        {
            return View("Login");
        }

        public Int32 IniciarSesion(Usuario usuario)
        {
            if (Gestionar_Usuario_Servicio.Instancia.IniciarSesion(usuario)) return 1;
            else return 0;
        }

        public ActionResult Index()
        {
            return View("Index");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}