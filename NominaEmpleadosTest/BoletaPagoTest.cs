using System;
using Dominio;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NominaEmpleadosTest
{
    [TestClass]
    public class BoletaPagoTest
    {
        [TestMethod]
        public void Test_CalcularTotalHoras()
        {
            PeriodoPago periodoPago = new PeriodoPago
            {
                FechaInicio = DateTime.Parse("10/10/2019"),
                FechaFin = DateTime.Parse("10/11/2019")
            };
            BoletaPago boletaPago = new BoletaPago
            {
                PeriodoPago = periodoPago,
                TotalHoras = 40
            };
            int CalcularTotalHoras_Esperado = 160;
            int CalcularTotalHoras_Obtenido = boletaPago.CalcularTotalHoras();
            Assert.AreEqual(CalcularTotalHoras_Esperado, CalcularTotalHoras_Obtenido);
        }

        [TestMethod]
        public void Test_CalcularSueldoBasico()
        {
            PeriodoPago periodoPago = new PeriodoPago
            {
                FechaInicio = DateTime.Parse("10/10/2019"),
                FechaFin = DateTime.Parse("10/11/2019")
            };
            BoletaPago boletaPago = new BoletaPago
            {
                PeriodoPago = periodoPago,
                TotalHoras = 40,
                ValorHora = 12,
            };
            Decimal CalcularSueldoBasico_Esperado = 1920;
            Decimal CalcularSueldoBasico_Obtenido = boletaPago.CalcularSueldoBasico();
            Assert.AreEqual(CalcularSueldoBasico_Esperado, CalcularSueldoBasico_Obtenido);
        }


        [TestMethod]
        public void Test1_CalcularAsignacionFamiliar()
        {
            PeriodoPago periodoPago = new PeriodoPago
            {
                FechaInicio = DateTime.Parse("10/10/2019"),
                FechaFin = DateTime.Parse("10/11/2019")
            };
            Contrato contrato = new Contrato
            {
                AsignacionFamiliar = true
            };
            BoletaPago boletaPago = new BoletaPago
            {
                PeriodoPago = periodoPago,
                Contrato = contrato,
                TotalHoras = 40,
                ValorHora = 10,
            };
            Decimal CalcularAsignacionFamiliar_Esperado = 160;
            Decimal CalcularAsignacionFamiliar_Obtenido = boletaPago.CalcularAsignacionFamiliar();
            Assert.AreEqual(CalcularAsignacionFamiliar_Esperado, CalcularAsignacionFamiliar_Obtenido);
        }

        [TestMethod]
        public void Test2_CalcularAsignacionFamiliar()
        {
            PeriodoPago periodoPago = new PeriodoPago
            {
                FechaInicio = DateTime.Parse("12/10/2019"),
                FechaFin = DateTime.Parse("10/12/2019")
            };
            Contrato contrato = new Contrato
            {
                AsignacionFamiliar = false
            };
            BoletaPago boletaPago = new BoletaPago
            {
                PeriodoPago = periodoPago,
                Contrato = contrato,
                TotalHoras = 30,
                ValorHora = 20,
            };
            Decimal CalcularAsignacionFamiliar_Esperado = 0;
            Decimal CalcularAsignacionFamiliar_Obtenido = boletaPago.CalcularAsignacionFamiliar();
            Assert.AreEqual(CalcularAsignacionFamiliar_Esperado, CalcularAsignacionFamiliar_Obtenido);
        }

        [TestMethod]
        public void Test1_CalcularDescuentoAFP()
        {
            PeriodoPago periodoPago = new PeriodoPago
            {
                FechaInicio = DateTime.Parse("10/10/2019"),
                FechaFin = DateTime.Parse("10/11/2019")
            };
            AFP aFP = new AFP
            {
                Porcentaje = 13
            };
            Contrato contrato = new Contrato
            {
                AsignacionFamiliar = true,
                AFP = aFP
            };
            BoletaPago boletaPago = new BoletaPago
            {
                PeriodoPago = periodoPago,
                Contrato = contrato,
                TotalHoras = 40,
                ValorHora = 10,
            };
            Decimal CalcularDescuentoAFP_Esperado = 208;
            Decimal CalcularDescuentoAFP_Obtenido = boletaPago.CalcularDescuentoAFP();
            Assert.AreEqual(CalcularDescuentoAFP_Esperado, CalcularDescuentoAFP_Obtenido);
        }

        [TestMethod]
        public void Test1_CalcularTotalIngresos()
        {
            PeriodoPago periodoPago = new PeriodoPago
            {
                FechaInicio = DateTime.Parse("10/10/2019"),
                FechaFin = DateTime.Parse("10/11/2019")
            };
            //AFP aFP = new AFP
            //{
            //    Porcentaje = 13
            //};
            Contrato contrato = new Contrato
            {
                AsignacionFamiliar = true,
                //AFP = aFP
            };
            Conceptos conceptos = new Conceptos
            {
                HorasExtras = 120,
                Reintegros = 70,
                OtrosIngresos = 40
            };
            BoletaPago boletaPago = new BoletaPago
            {
                PeriodoPago = periodoPago,
                Contrato = contrato,
                Conceptos = conceptos,
                TotalHoras = 40,
                ValorHora = 10,
            };
            Decimal CalcularTotalIngresos_Esperado = 1990;
            Decimal CalcularTotalIngresos_Obtenido = boletaPago.CalcularTotalIngresos();
            Assert.AreEqual(CalcularTotalIngresos_Esperado, CalcularTotalIngresos_Obtenido);
        }

        [TestMethod]
        public void Test1_CalcularTotalDescuentos()
        {
            PeriodoPago periodoPago = new PeriodoPago
            {
                FechaInicio = DateTime.Parse("10/10/2019"),
                FechaFin = DateTime.Parse("10/11/2019")
            };
            AFP aFP = new AFP
            {
                Porcentaje = 13
            };
            Contrato contrato = new Contrato
            {
                //AsignacionFamiliar = true,
                AFP = aFP
            };

            Conceptos conceptos = new Conceptos
            {
                Adelanto = 150,
                HorasAusentes = 50,
                OtrosDescuentos = 20
            };
            //Conceptos conceptos = new Conceptos
            //{
            //    HorasExtas = 120,
            //    Reintegros = 70,
            //    OtrosIngresos = 40
            //};
            BoletaPago boletaPago = new BoletaPago
            {
                PeriodoPago = periodoPago,
                Contrato = contrato,
                Conceptos = conceptos,
                TotalHoras = 40,
                ValorHora = 10,
            };
            Decimal CalcularTotalDescuentos_Esperado = -428;
            Decimal CalcularTotalDescuentos_Obtenido = boletaPago.CalcularTotalDescuentos();
            Assert.AreEqual(CalcularTotalDescuentos_Esperado, CalcularTotalDescuentos_Obtenido);
        }

        [TestMethod]
        public void Test1_CalcularSueldoNeto()
        {
            PeriodoPago periodoPago = new PeriodoPago
            {
                FechaInicio = DateTime.Parse("10/10/2019"),
                FechaFin = DateTime.Parse("10/11/2019")
            };
            AFP aFP = new AFP
            {
                Porcentaje = 13
            };
            Contrato contrato = new Contrato
            {
                AsignacionFamiliar = true,
                AFP = aFP
            };

            Conceptos conceptos = new Conceptos
            {
                Adelanto = 150,
                HorasAusentes = 50,
                OtrosDescuentos = 20,
                HorasExtras = 120,
                Reintegros = 70,
                OtrosIngresos = 40
            };
            BoletaPago boletaPago = new BoletaPago
            {
                PeriodoPago = periodoPago,
                Contrato = contrato,
                Conceptos = conceptos,
                TotalHoras = 40,
                ValorHora = 10,
            };
            Decimal CalcularSueldoNeto_Esperado = 1562;
            Decimal CalcularSueldoNeto_Obtenido = boletaPago.CalcularSueldoNeto();
            Assert.AreEqual(CalcularSueldoNeto_Esperado, CalcularSueldoNeto_Obtenido);
        }
    }
}
