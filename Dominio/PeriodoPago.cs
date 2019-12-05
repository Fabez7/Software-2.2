using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class PeriodoPago:EntidadBase
    {
        public int Id_PeriodoPago { get; set; }
        public String Estado { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }

        public bool ValidarPeriodoPago()
        {
            if (System.DateTime.Now.CompareTo(FechaFin) >= 0)
                return true;
            else return false;
        }
        public Int32 CalcularSemanasPeriodo()
        {
            TimeSpan diferencia = FechaFin - FechaInicio;
            Int32 dias = Int32.Parse(diferencia.TotalDays.ToString());
            return dias / 7;
        }


    }
}
