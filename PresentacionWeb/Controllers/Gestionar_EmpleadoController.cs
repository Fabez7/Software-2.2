using Aplicacion;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PresentacionWeb.Controllers
{
    public class Gestionar_EmpleadoController : Controller
    {
        // GET: Empleado
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult BuscarEmpleado(String DNI)
        {
            Empleado empleado = EmpleadoAP.Instancia.BuscarEmpleado(DNI);
            if (empleado.Id_Empleado==0)
            {
                return PartialView("_Error");
            }
            else return PartialView("_VerEmpleado", EmpleadoAP.Instancia.BuscarEmpleado(DNI));
        }
    }
}