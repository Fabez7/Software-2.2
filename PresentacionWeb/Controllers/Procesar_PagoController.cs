using Aplicacion;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PresentacionWeb.Controllers
{
    public class Procesar_PagoController : Controller
    {
        // GET: Pago
        public ActionResult Inicio()
        {
            PeriodoPago periodoPago = Procesar_Pago_Servicio.Instancia.ObtenerPeriodo();
            if (periodoPago.Id_PeriodoPago == 0)
            {
                return View("Error");
            }
            else return View("Inicio",periodoPago);
        }

        public ActionResult ProcesarPago(PeriodoPago periodoPago)
        {
            List<BoletaPago> boletas = new List<BoletaPago>();
            string rpta = Procesar_Pago_Servicio.Instancia.ProcesarPago(periodoPago,ref boletas);
            if (rpta == "OK")
            {
                return PartialView("_ProcesarPago", boletas);
            }
            else if (rpta == "R01")
            {
                ViewBag.rpta = "No hay un periodo de Pago Vigente";
                return PartialView("_Error",rpta);
            }
            else if (rpta == "NC")
            {
                ViewBag.rpta = "No hay Contratos Vigentes";
                return PartialView("_Error", rpta);
            }
            else
            {
                ViewBag.rpta = "Error al registrar intente de nuevo";
                return PartialView("_Error", rpta);
            }
        }
    }
}