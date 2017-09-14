using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TarjetaCredito.Models;

namespace TarjetaCredito.Controllers
{
    public class TarjetaCreditoController : Controller
    {
        // GET: TarjetaCredito
        public ActionResult Index()
        {
            return HttpNotFound();
        }


        
        public ActionResult Validar()
        {
            if (Request.HttpMethod == "POST")
            {
                string numeroTarjeta = Request.Form.GetValues("numero")[0];
                TarjetaCredito.Models.TarjetaCredito nuevaTarjeta = 
                    new TarjetaCredito.Models.TarjetaCredito(numeroTarjeta);
                if (!nuevaTarjeta.validar())
                    return View(nuevaTarjeta);
                else
                    return View("ValidacionExitosa",nuevaTarjeta);
            }
            else
                return View();
        }

        public ActionResult ListarTarjetas()
        {
            List<TarjetaCredito.Models.TarjetaCredito> listado = TarjetaCreditoDAL.obtenerTarjetas();
            return View(listado);

        }
    }
}