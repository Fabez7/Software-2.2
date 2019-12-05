using System;
using Dominio;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NominaEmpleadosTest
{
    [TestClass]
    public class PerdiodoPagoTest
    {
        [TestMethod]
        public void Test1_ValidarPeriodoPago()
        {
            PeriodoPago periodoPago = new PeriodoPago
            {
                FechaFin = DateTime.Parse("10/10/2019")
            };
            bool ValidarPeriodoPago_Esperado = true;
            bool ValidarPeriodoPago_Obtenido = periodoPago.ValidarPeriodoPago();
            Assert.AreEqual(ValidarPeriodoPago_Esperado, ValidarPeriodoPago_Obtenido);
        }

        [TestMethod]
        public void Test2_ValidarPeriodoPago()
        {
            PeriodoPago periodoPago = new PeriodoPago
            {
                FechaFin = DateTime.Parse("10/11/2019")
            };
            bool ValidarPeriodoPago_Esperado = false;
            bool ValidarPeriodoPago_Obtenido = periodoPago.ValidarPeriodoPago();
            Assert.AreEqual(ValidarPeriodoPago_Esperado, ValidarPeriodoPago_Obtenido);
        }

        [TestMethod]
        public void Test1_CalcularSemanasPeriodo()
        {
            PeriodoPago periodoPago = new PeriodoPago
            {
                FechaInicio = DateTime.Parse("10/10/2019"),
                FechaFin = DateTime.Parse("10/11/2019")
            };
            int CalcularSemanasPeriodo_Esperado = 4;
            int CalcularSemanasPeriodo_Obtenido = periodoPago.CalcularSemanasPeriodo();
            Assert.AreEqual(CalcularSemanasPeriodo_Esperado, CalcularSemanasPeriodo_Obtenido);
        }
    }
}
