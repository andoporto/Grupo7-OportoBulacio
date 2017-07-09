using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CapaNegocioDatos;
using CapaNegocioDatos.Servicios;

namespace Cinemania.Models.Servicios
{
    public abstract class HoraService
    {
        public static List<Horas> sacarHorasReserva(int IdPelicula, int IdSede, int IdVersion)
        {
            DalCartelera DalCar = new DalCartelera();

            var traerCartelera = DalCar.CarteleraPeliSedeYVersion(IdPelicula, IdSede, IdVersion);

            List<Horas> listaHoras = new List<Horas>();

            int hora;
            int minutos;
            string FinalFuncion = "";
            int FinalFuncionSegundos = 0;
            int HoraInicio = traerCartelera.HoraInicio;
            int DuracionPelicula = traerCartelera.Peliculas.Duracion;

            for(int i = 1; i <= 7; i++)
            {
                //La primera vez toma la hora de inicio de la primera peli
                if (i == 1)
                {
                    hora = (HoraInicio) / 3600;
                    minutos = (HoraInicio % 3600) / 60;
                    FinalFuncionSegundos = ((DuracionPelicula) * 60) + HoraInicio;
                }
                else
                {
                    hora = FinalFuncionSegundos / 3600;
                    minutos = (FinalFuncionSegundos % 3600) / 60;
                    FinalFuncionSegundos += ((DuracionPelicula) * 60) + 1800;  

                    if (FinalFuncionSegundos > 86400)
                    {
                        FinalFuncionSegundos = FinalFuncionSegundos - 86400;
                    }
                }

                string txtMinutos;
                string HoraFormato;

                if (minutos < 10)
                {
                    txtMinutos = "0" + minutos;
                    HoraFormato = String.Format("{0}:{1}", hora, txtMinutos);
                }
                else
                {
                    HoraFormato = String.Format("{0}:{1}", hora, minutos);
                }

                hora = FinalFuncionSegundos / 3600;
                minutos = (FinalFuncionSegundos % 3600) / 60;
                if (minutos < 10)
                {
                    txtMinutos = "0" + minutos;
                    FinalFuncion = String.Format("{0}:{1}", hora, txtMinutos);
                }
                else
                {
                    FinalFuncion = String.Format("{0}:{1}", hora, minutos);
                }

                FinalFuncion += 1800; //Media hora de intervalo.

                if (FinalFuncionSegundos > 86400)
                {
                    FinalFuncionSegundos = FinalFuncionSegundos - 86400;
                }

                listaHoras.Add(new Horas() { Id = HoraFormato, Hora = HoraFormato });
            }

            return listaHoras;
        }
    }
}