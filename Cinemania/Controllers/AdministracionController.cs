using CapaNegocioDatos;
using CapaNegocioDatos.Servicios;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cinemania.Controllers
{
    public class AdministracionController : Controller
    {
        // BASE DE DATOS
        Context db = new Context();

        DalPeliculas DalPeli = new DalPeliculas();
        DalSedes DalSede = new DalSedes();
        DalCartelera DalCar = new DalCartelera();
        DalReservas DalRes = new DalReservas();

        public object lPeli { get; private set; }

        // GET: Administracion
        public ActionResult Inicio()
        {
            if(!String.IsNullOrEmpty(Session["Logueado"].ToString()))
            {
                return RedirectToAction("Login", "Home");
            }
            return View();
        }

        public ActionResult Peliculas()
        {
            if (!String.IsNullOrEmpty(Session["Logueado"].ToString()))
            {
                return RedirectToAction("Login", "Home");
            }

            var listaPeliculas = DalPeli.ListarPeliculas();
            var listaCalificaciones = DalPeli.TraerCalificaciones();

            ViewBag.listaCalificaciones = new SelectList(listaCalificaciones, "IdCalificaciones", "Nombre");

            return View(listaPeliculas);
        }

        // GET: Peliculas/NuevoPelicula

        public ActionResult NuevoPelicula()
        {
            if (!String.IsNullOrEmpty(Session["Logueado"].ToString()))
            {
                return RedirectToAction("Login", "Home");
            }

            var listaCalificaciones = DalPeli.TraerCalificaciones();
            var listaGeneros = DalPeli.TraerGeneros();
            var listaPeliculas = DalPeli.ListarPeliculas();

            ViewBag.IdCalificacion = new SelectList(listaCalificaciones, "IdCalificacion", "Nombre");
            ViewBag.IdGenero = new SelectList(listaGeneros, "IdGenero", "Nombre");
            ViewBag.listaPeliculas = new SelectList(listaPeliculas, "IdPelicula", "Nombre");

            return View();

        }

        [HttpPost]
        public ActionResult NuevoPelicula(Peliculas Pelicula)
        {
            var file = Request.Files[0];

            if (ModelState.IsValid)
            {
                if (file.ContentLength > 0)
                {
                    Peliculas pel = new Peliculas();

                    string _filename = Path.GetFileName(file.FileName);
                    string _patch = Path.Combine(Server.MapPath("~/Imagenes"), _filename);
                    file.SaveAs(_patch);

                    pel.Nombre = Pelicula.Nombre;
                    pel.Descripcion = Pelicula.Descripcion;
                    pel.Imagen = _patch;
                    pel.Duracion = Pelicula.Duracion;
                    pel.IdGenero = Pelicula.IdGenero;
                    pel.IdCalificacion = Pelicula.IdCalificacion;

                    DalPeli.AgregarPeliculas(pel);

                    return RedirectToAction("Peliculas"); // Retorna a la vista "Peliculas"
                    }
                }

              TempData["MensajeError"] = "Error subiendo el archivo";

              return View();
        }

        //GET: Peliculas/EditarPelicula
        public ActionResult EditarPelicula(int? IdPelicula)
        {
            if (!String.IsNullOrEmpty(Session["Logueado"].ToString()))
            {
                return RedirectToAction("Login", "Home");
            }

            var pel = DalPeli.TraerPelicula(IdPelicula);
            var listaCalificaciones = DalPeli.TraerCalificaciones();
            var listaGeneros = DalPeli.TraerGeneros();

            ViewBag.IdCalificacion = new SelectList(listaCalificaciones, "IdCalificacion", "Nombre");
            ViewBag.IdGenero = new SelectList(listaGeneros, "IdGenero", "Nombre");

            return View(pel);
        }

        [HttpPost]
        public ActionResult EditarPelicula(Peliculas pel, int IdPelicula)
        {
            var file = Request.Files[0];
            pel.IdPelicula = IdPelicula;

            if (ModelState.IsValid)
            {
                if (file.ContentLength > 0)
                {
                    string _filename = Path.GetFileName(file.FileName);
                    string _patch = Path.Combine(Server.MapPath("~/Imagenes"), _filename);
                    file.SaveAs(_patch);
                    pel.Imagen = _patch;

                    DalPeli.EditarPelicula(pel, pel.IdPelicula);

                    TempData["MensajeCorrecto"] = "Cambios guardados";

                    return RedirectToAction("Peliculas");
                 }
            }

            TempData["Mensaje"] = "Error subiendo el archivo";

            return RedirectToAction("Peliculas");
        }

        public ActionResult BorrarPelicula(int IdPelicula)
        {
            DalPeli.EliminarPelicula(IdPelicula);

            return RedirectToAction("Peliculas");
        }

        // GET: Administracion/Sedes
        public ActionResult Sedes()
        {
            if (!String.IsNullOrEmpty(Session["Logueado"].ToString()))
            {
                return RedirectToAction("Login", "Home");
            }

            var listaSedes = DalSede.ListarSedes();

            return View(listaSedes);
        }

        // GET: Sedes/NuevoSede
        public ActionResult NuevoSede()
        {
            if (!String.IsNullOrEmpty(Session["Logueado"].ToString()))
            {
                return RedirectToAction("Login", "Home");
            }

            var listaSedes = DalSede.ListarSedes();

            ViewBag.listaSedes = new SelectList(listaSedes, "IdSede", "Nombre");
            return View();
        }

        [HttpPost]
        public ActionResult NuevoSede(Sedes Sede)
        {
            if (!String.IsNullOrEmpty(Session["Logueado"].ToString()))
            {
                return RedirectToAction("Login", "Home");
            }

            if (ModelState.IsValid)
            {
                DalSede.AgregarSedes(Sede);

                return RedirectToAction("Sedes"); // Retorna a la vista "Sedes"
            }
            return View();
        }

        //GET: Sedes/EditarSede
        public ActionResult EditarSede(int IdSede)
        {
            if (!String.IsNullOrEmpty(Session["Logueado"].ToString()))
            {
                return RedirectToAction("Login", "Home");
            }

            var sede = DalSede.TraerSede(IdSede);

            return View(sede);
        }

        [HttpPost]
        public ActionResult EditarSede(Sedes sed, int IdSede)
        {
            if (ModelState.IsValid)
            {
                DalSede.EditarSedes(sed, IdSede);
            }

            return RedirectToAction("Sedes");
        }

        public ActionResult BorrarSede(int IdSede)
        {
            DalSede.EliminarSede(IdSede);
                
            return RedirectToAction("Sedes");
        }

        public ActionResult Carteleras()
        {
            if (!String.IsNullOrEmpty(Session["Logueado"].ToString()))
            {
                return RedirectToAction("Login", "Home");
            }

            var listaCarteleras = DalCar.ListarCarteleras();
            var ListaCalificaciones = DalPeli.TraerCalificaciones();

            ViewBag.listaCalificaciones = new SelectList(ListaCalificaciones, "IdCalificaciones", "Nombre");

            return View(listaCarteleras);
        }

        // GET: Administracion/Carteleras
        public ActionResult NuevoCartelera()
        {
            if (!String.IsNullOrEmpty(Session["Logueado"].ToString()))
            {
                return RedirectToAction("Login", "Home");
            }

            var ListaSedes = DalSede.ListarSedes();
            var ListaPeliculas = DalPeli.ListarPeliculas();
            var ListaVersiones = DalPeli.TraerVersiones();

            ViewBag.IdSede = new SelectList(ListaSedes, "IdSede", "Nombre");
            ViewBag.IdPelicula = new SelectList(ListaPeliculas, "IdPelicula", "Nombre");
            ViewBag.IdVersion = new SelectList(ListaVersiones, "IdVersion", "Nombre");
            return View();
        }

        [HttpPost]
        public ActionResult NuevoCartelera(Carteleras Cartelera)
        {
            if (ModelState.IsValid)
            {
                DalCar.AgregarCarteleras(Cartelera);

                return RedirectToAction("Carteleras"); // Retorna a la vista "Carteleras"
            }
            return RedirectToAction("Carteleras");
        }

        public ActionResult EditarCartelera(int IdCartelera)
        {
            if (!String.IsNullOrEmpty(Session["Logueado"].ToString()))
            {
                return RedirectToAction("Login", "Home");
            }

            var Cartelera = DalCar.TraerCartelera(IdCartelera);
            var ListaSedes = DalSede.ListarSedes();
            var ListaPeliculas = DalPeli.ListarPeliculas();
            var ListaVersiones = DalPeli.TraerVersiones();

            ViewBag.IdSede = new SelectList(ListaSedes, "IdSede", "Nombre");
            ViewBag.IdPelicula = new SelectList(ListaPeliculas, "IdPelicula", "Nombre");
            ViewBag.IdVersion = new SelectList(ListaVersiones, "IdVersion", "Nombre");
            return View(Cartelera);
        }

        [HttpPost]
        public ActionResult EditarCartelera(int IdCartelera, Carteleras car)
        {
            if (ModelState.IsValid)
            {
                DalCar.EditarCartelera(IdCartelera, car);
            }

            return RedirectToAction("Carteleras");
        }

        public ActionResult BorrarCartelera(int IdCartelera)
        {
            DalCar.EliminarCartelera(IdCartelera);

            return RedirectToAction("Carteleras");
        }

        // GET: Administracion/Reportes
        public ActionResult Reportes()
        {
            if (!String.IsNullOrEmpty(Session["Logueado"].ToString()))
            {
                return RedirectToAction("Login", "Home");
            }

            return View();
        }

        public ActionResult ListaReportes(FormCollection Fechas)
        {
            if (!String.IsNullOrEmpty(Session["Logueado"].ToString()))
            {
                return RedirectToAction("Login", "Home");
            }

            string FechaDesde = Fechas["FechaDesde"];
            string FechaHasta = Fechas["FechaHasta"];

            if (String.IsNullOrEmpty(FechaDesde) || String.IsNullOrEmpty(FechaHasta))
            {
                return RedirectToAction("Reportes");
            }

            DateTime FechaInicio = DateTime.ParseExact(FechaDesde, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
            DateTime FechaFin = DateTime.ParseExact(FechaHasta, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);

            var CantidadDias = (FechaFin - FechaInicio).TotalDays;

            if(FechaInicio > FechaFin)
            {
                TempData["Error"] = "La fecha de inicio no puede ser mayor a la de fin";

                return RedirectToAction("Reportes");
            }

            if(CantidadDias > 30)
            {
                TempData["Error"] = "El periodo de consulta no puede ser superior a 30 días";

                return RedirectToAction("Reportes");
            }

            var Reservas = DalRes.TraerReservasFechas(FechaInicio, FechaFin);
            
            return View(Reservas);
        }
    }
}