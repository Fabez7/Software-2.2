using System;
using Dominio;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NominaEmpleadosTest
{
    [TestClass]
    public class ConceptosTest
    {
        [TestMethod]
        public void Test_SumarConceptoDescuentos()
        {
            Conceptos conceptos = new Conceptos
            {
                Adelanto = 150,
                HorasAusentes = 50,
                OtrosDescuentos = 20
            };

            Decimal SumarConceptoDescuentos_Esperado = 220;
            Decimal SumarConceptoDescuentos_Obtenido = conceptos.SumarConceptoDescuentos();
            Assert.AreEqual(SumarConceptoDescuentos_Esperado, SumarConceptoDescuentos_Obtenido);
        }

        [TestMethod]
        public void Test_SumarConceptoIngresos()
        {
            Conceptos conceptos = new Conceptos
            {
                HorasExtras = 120,
                Reintegros = 70,
                OtrosIngresos = 40
            };

            Decimal SumarConceptoIngresos_Esperado = 230;
            Decimal SumarConceptoIngresos_Obtenido = conceptos.SumarConceptoIngresos();
            Assert.AreEqual(SumarConceptoIngresos_Esperado, SumarConceptoIngresos_Obtenido);
        }
    }
}
