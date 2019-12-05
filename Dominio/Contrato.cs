using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Contrato:EntidadBase
    {
        public int Id_Contrato { get; set; }
        public Boolean Anulado { get; set; }
        public Boolean AsignacionFamiliar { get; set; }
        public AFP AFP { get; set; }
        public Cargo Cargo { get; set; }
        public Empleado Empleado { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public Int32 HorasContratadas { get; set; }
        public Decimal ValorHora { get; set; }

        public Boolean ObtenerVigencia()
        {
            DateTime fechaActual = DateTime.Now.Date;
            return (FechaFin.CompareTo(fechaActual)>=0 && !Anulado);
        }

        public Boolean ValidarFechaContrato(DateTime FechaAnterior)
        {
            if (FechaInicio.CompareTo(FechaAnterior) == 1)
                return true;
            else return false;
        }

        public Boolean ValidarHoraSemana()
        {
            return HorasContratadas >= 8 && HorasContratadas <= 40;
        }

        public Boolean ValidarPagoHora()
        {

            if (Empleado.GradoAcademico == "Primaria" || Empleado.GradoAcademico == "Secundaria")
            {
                return ValorHora >= 5 && ValorHora <= 10;
            }
            else if (Empleado.GradoAcademico == "Bachiller")
            {
                return ValorHora >= 11 && ValorHora <= 20;
            }

            else if (Empleado.GradoAcademico == "Profesional")
            {
                return ValorHora >= 21 && ValorHora <= 30;
            }

            else if (Empleado.GradoAcademico == "Magister")
            {
                return ValorHora >= 31 && ValorHora <= 40;
            }

            else if (Empleado.GradoAcademico == "Doctor")
            {
                return ValorHora >= 41 && ValorHora <= 60;
            }
            else return false;

        }

        public Boolean ValidarPeriodoContrato()
        {
            TimeSpan diferencia = FechaFin - FechaInicio;
            Int32 Periodo = Int32.Parse(diferencia.TotalDays.ToString())/30;
            return FechaFin.CompareTo(FechaInicio)==1 && Periodo >= 3 && Periodo <= 12;
        }





    }
}
