using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaNegocioDatos;
using CapaNegocioDatos.Servicios;

namespace Cinemania.Controllers
{
    public class HomeController : Controller
    {
        DalPeliculas DalPeli = new DalPeliculas();
        DalLogin DalLog = new DalLogin();

        // GET: Home
        public ActionResult Inicio()
        {
            var listaPeliculas = DalPeli.ListarPeliculas();

            return View(listaPeliculas);
        }

        // GET: Home/Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ValidarLogin(FormCollection form)
        {
            var nombreUsuario = form["Email"].ToString();
            var Pass = form["PassUsuario"].ToString();

            var resultado = DalLog.ValidarLog(nombreUsuario, Pass);

            //Si la variable está en null significa que no se encontró al usuario
            if (resultado == null)
            {
                //Mensaje validación
                TempData["Validacion"] = "Datos inválidos/Usuario no encontrado";
                return RedirectToAction("../Home/Login");
            }

            Session["Logueado"] = "Sí";

            return RedirectToAction("../Administracion/Inicio");
        }

        public ActionResult CerrarSesion()
        {
            Session["Logueado"] = null;

            return RedirectToAction("Home", "Inicio");
        }
    }
}