using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class BoletaPago:EntidadBase
    {
        public Decimal AsignacionFamiliar { get; set; }
        public Conceptos Conceptos { get; set; }
        public Contrato Contrato { get; set; }
        public DateTime FechaPago { get; set; }
        public PeriodoPago PeriodoPago { get; set; }
        public Decimal PorcentajeAFP { get; set; }
        public Int32 TotalHoras { get; set; }
        public Decimal ValorHora { get; set; }

        public Int32 CalcularTotalHoras()
        {
            return (PeriodoPago.CalcularSemanasPeriodo() * Contrato.HorasContratadas);

        }

        public Decimal CalcularSueldoBasico()
        {
            return CalcularTotalHoras() * ValorHora;
        }

        public Decimal CalcularAsignacionFamiliar()
        {
            if (Contrato.AsignacionFamiliar)
            {
                return CalcularSueldoBasico() * 0.1m;
            }
            else return 0;
        }

        public Decimal CalcularDescuentoAFP()
        {
            return Contrato.AFP.Porcentaje * CalcularSueldoBasico()/100;
        }

        public Decimal CalcularTotalIngresos()
        {
            return CalcularSueldoBasico() + CalcularAsignacionFamiliar() + Conceptos.SumarConceptoIngresos();
        }

        public Decimal CalcularTotalDescuentos()
        {
            return -1 * (CalcularDescuentoAFP() + Conceptos.SumarConceptoDescuentos());
        }

        public Decimal CalcularSueldoNeto()
        {
            return CalcularTotalIngresos() + CalcularTotalDescuentos();
        }                  
    }
}
