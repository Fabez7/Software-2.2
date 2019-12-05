using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Conceptos:EntidadBase
    {
        public int Id_Conceptos { get; set; }
        public Decimal Adelanto { get; set; }
        public Decimal HorasAusentes { get; set; }
        public Decimal HorasExtras { get; set; }
        public Decimal OtrosDescuentos { get; set; }
        public Decimal OtrosIngresos { get; set; }
        public Decimal Reintegros { get; set; }

        public Decimal SumarConceptoDescuentos()
        {
            return Adelanto + HorasAusentes + OtrosDescuentos;
        }

        public Decimal SumarConceptoIngresos()
        {
            return HorasExtras + OtrosIngresos + Reintegros;
        }
    }
}
