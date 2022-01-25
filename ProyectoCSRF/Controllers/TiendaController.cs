using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoCSRF.Controllers
{
    public class TiendaController : Controller
    {
        public IActionResult Productos()
        {
            if (HttpContext.Session.GetString("USUARIO") == null)
            {
                return RedirectToAction("AccesoDenegado", "Managed");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public IActionResult Productos(string direccion, string[] producto)
        {
            if (HttpContext.Session.GetString("USUARIO") == null)
            {
                return RedirectToAction("AccesoDenegado", "Managed");
            }
            //NECESITAMOS ENVIAR INFORMACION DESDE
            //PRODUCTOS HASTA CARRITO
            TempData["PRODUCTOS"] = producto;
            TempData["DIRECCION"] = direccion;
            return RedirectToAction("Carrito");
        }

        public IActionResult Carrito()
        {
            string[] productos = TempData["PRODUCTOS"] as string[];
            string direccion = TempData["DIRECCION"].ToString();
            ViewBag.Direccion = direccion;
            return View(productos);
        }
    }
}
