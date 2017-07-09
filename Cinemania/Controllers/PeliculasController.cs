using CapaNegocioDatos;
using CapaNegocioDatos.Servicios;
using Cinemania.Models;
using Cinemania.Models.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cinemania.Controllers
{
    public class PeliculasController : Controller
    {
        DalPeliculas DalPeli = new DalPeliculas();
        DalSedes DalSed = new DalSedes();
        DalCartelera DalCar = new DalCartelera();
        DalDocumentos Doc = new DalDocumentos();
        DalReservas DalRes = new DalReservas();

        // GET: Peliculas
        public ActionResult Reserva(int IdPelicula)
        {   
            var listaVersiones = DalPeli.TraerVersiones();
            var pelicula = DalPeli.TraerPelicula(IdPelicula);

            ViewBag.NombrePelicula = pelicula.Nombre;
            ViewBag.IdPelicula = IdPelicula;
            ViewBag.listaVersiones = new SelectList(listaVersiones, "IdVersion", "Nombre");

            return View();
        }

        [HttpPost]
        public ActionResult Reserva(FormCollection form)
        {
            int IdPelicula = Convert.ToInt32(form["IdPelicula"]);
            int IdVersion = Convert.ToInt32(form["IdVersion"]);
            int IdSede = Convert.ToInt32(form["IdSede"]);
            string Dia = form["DiasReservas"];
            string Hora = form["HorasReservas"];

            string FechaCompleta = Dia + " " + Hora;
            DateTime FechaReserva = Convert.ToDateTime(FechaCompleta);

            TempData["IdPelicula"] = IdPelicula;
            TempData["IdVersion"] = IdVersion;
            TempData["IdSede"] = IdSede;
            TempData["FechaReserva"] = FechaReserva;

            return RedirectToAction("ConfirmarReserva", "Peliculas");
        }

        public ActionResult ConfirmarReserva()
        {
            var tipoDocumentos = Doc.TraerTiposDocumentos();

            ViewBag.IdPelicula = TempData["IdPelicula"];
            ViewBag.IdVersion = TempData["IdVersion"];
            ViewBag.IdSede = TempData["IdSede"];
            ViewBag.FechaReserva = TempData["FechaReserva"];
            ViewBag.tipoDNI = new SelectList(tipoDocumentos, "IdTipoDocumento", "Descripcion");

            return View();
        }

        [HttpPost]
        public ActionResult ConfirmarReserva(Reservas r)
        {
            if(ModelState.IsValid)
            {
                DalRes.AgregarReserva(r);

                var Sede = DalSed.TraerSede(r.IdSede);
                decimal Precio = Sede.PrecioGeneral;

                var Total = r.CantidadEntradas * Precio;

                TempData["Total"] = Total;

                return RedirectToAction("ReservaConfirmada", "Peliculas");
            }

            TempData["Error"] = "Hubo un error al confirmar la reserva. Vuelva a ingresar los datos";

            return RedirectToAction("Reserva", "Peliculas");
        }

        public ActionResult ReservaConfirmada()
        {
            ViewBag.Total = TempData["Total"];


            return View();
        }

        public JsonResult TraerListaSedes(int IdPelicula, int IdVersion)
        {
            List<Sedes> listaSedes = DalSed.ListarPorPeliYCartelera(IdPelicula, IdVersion);

            return Json(listaSedes, JsonRequestBehavior.AllowGet);
        }

        public JsonResult TraerListaDias(int IdPelicula, int IdVersion, int IdSede)
        {
            if (IdPelicula == 0 || IdVersion == 0 || IdSede == 0)
            {
                List<Dias> listaDiasVacia = new List<Dias>();

                return Json(listaDiasVacia, JsonRequestBehavior.AllowGet);
            }

            var ListaDias = DiaService.sacarDiasReservas(IdPelicula, IdSede, IdVersion);

            return Json(ListaDias, JsonRequestBehavior.AllowGet);
        }

        public JsonResult TraerListaHoras(int IdPelicula, int IdVersion, int IdSede)
        {
            if (IdPelicula == 0 || IdVersion == 0 || IdSede == 0)
            {
                List<Dias> listaHorasVacia = new List<Dias>();

                return Json(listaHorasVacia, JsonRequestBehavior.AllowGet);
            }

            var ListaHoras = HoraService.sacarHorasReserva(IdPelicula, IdSede, IdVersion);

            return Json(ListaHoras, JsonRequestBehavior.AllowGet);
        }
    }
}