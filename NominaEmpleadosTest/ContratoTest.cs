using Dominio;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace NominaEmpleadosTest
{
    [TestClass]
    public class ContratoTest
    {
        #region ObtenerVigencia
        [TestMethod]
        public void Test1_ObtenerVigencia()
        {
            Contrato contrato = new Contrato
            {
                FechaFin = DateTime.Parse("24/10/2019"),
                Anulado = true
            };

            bool ObtenerVigencia_Esperado = true;
            bool ObtenerVigencia_Obtenido = contrato.ObtenerVigencia();
            Assert.AreEqual(ObtenerVigencia_Esperado, ObtenerVigencia_Obtenido);
        }

        [TestMethod]
        public void Test2_ObtenerVigencia()
        {
            Contrato contrato = new Contrato
            {
                FechaFin = DateTime.Parse("04/10/2019"),
                Anulado = true
            };
            bool ObtenerVigencia_Esperado = false;
            bool ObtenerVigencia_Obtenido = contrato.ObtenerVigencia();
            Assert.AreEqual(ObtenerVigencia_Esperado, ObtenerVigencia_Obtenido);
        }

        [TestMethod]
        public void Test3_ObtenerVigencia()
        {
            Contrato contrato = new Contrato
            {
                FechaFin = DateTime.Parse("20/10/2019"),
                Anulado = false
            };

            bool ObtenerVigencia_Esperado = false;
            bool ObtenerVigencia_Obtenido = contrato.ObtenerVigencia();
            Assert.AreEqual(ObtenerVigencia_Esperado, ObtenerVigencia_Obtenido);
        }

        #endregion

        #region ValidarFechaContrato
        [TestMethod]
        public void Test1_ValidarFechaContrato()
        {
            Contrato contrato = new Contrato
            {
                FechaInicio = DateTime.Parse("05/10/2019")

            };
            DateTime FechaAnterior = DateTime.Parse("04/10/2019");
            bool FechaContrato_Esperado = true;
            bool FechaContrato_Obtenido = contrato.ValidarFechaContrato(FechaAnterior);
            Assert.AreEqual(FechaContrato_Esperado, FechaContrato_Obtenido);
        }

        [TestMethod]
        public void Test2_ValidarFechaContrato()
        {
            Contrato contrato = new Contrato
            {
                FechaInicio = DateTime.Parse("05/10/2019")

            };
            DateTime FechaAnterior = DateTime.Parse("06/10/2019");
            bool FechaContrato_Esperado = false;
            bool FechaContrato_Obtenido = contrato.ValidarFechaContrato(FechaAnterior);
            Assert.AreEqual(FechaContrato_Esperado, FechaContrato_Obtenido);
        }
        #endregion

        #region ValidarHoraSemana
        [TestMethod]
        public void Test1_ValidarHoraSemana()
        {
            Contrato contrato = new Contrato
            {
                HorasContratadas = 7
            };

            bool HoraSemana_Esperado = false;
            bool HoraSemana_Obtenido = contrato.ValidarHoraSemana();
            Assert.AreEqual(HoraSemana_Esperado, HoraSemana_Obtenido);
        }

        [TestMethod]
        public void Test2_ValidarHoraSemana()
        {
            Contrato contrato = new Contrato
            {
                HorasContratadas = 20
            };

            bool HoraSemana_Esperado = true;
            bool HoraSemana_Obtenido = contrato.ValidarHoraSemana();
            Assert.AreEqual(HoraSemana_Esperado, HoraSemana_Obtenido);
        }

        [TestMethod]
        public void Test3_ValidarHoraSemana()
        {
            Contrato contrato = new Contrato
            {
                HorasContratadas = 49
            };

            bool HoraSemana_Esperado = false;
            bool HoraSemana_Obtenido = contrato.ValidarHoraSemana();
            Assert.AreEqual(HoraSemana_Esperado, HoraSemana_Obtenido);
        }
        #endregion


        [TestMethod]
        public void Test1_ValidarPagoHora()
        {
            Empleado empleado = new Empleado
            {
                GradoAcademico = "Primaria"
            };
            Contrato contrato = new Contrato
            {
                ValorHora = 4,
                Empleado = empleado

            };

            bool PagoHora_Esperado = false;
            bool PagoHora_Obtenido = contrato.ValidarPagoHora();
            Assert.AreEqual(PagoHora_Esperado, PagoHora_Obtenido);
        }

        [TestMethod]
        public void Test2_ValidarPagoHora()
        {
            Empleado empleado = new Empleado
            {
                GradoAcademico = "Secundaria"
            };
            Contrato contrato = new Contrato
            {
                ValorHora = 7,
                Empleado = empleado

            };

            bool PagoHora_Esperado = true;
            bool PagoHora_Obtenido = contrato.ValidarPagoHora();
            Assert.AreEqual(PagoHora_Esperado, PagoHora_Obtenido);
        }

        [TestMethod]
        public void Test3_ValidarPagoHora()
        {
            Empleado empleado = new Empleado
            {
                GradoAcademico = "Secundaria"
            };
            Contrato contrato = new Contrato
            {
                ValorHora = 11,
                Empleado = empleado

            };

            bool PagoHora_Esperado = false;
            bool PagoHora_Obtenido = contrato.ValidarPagoHora();
            Assert.AreEqual(PagoHora_Esperado, PagoHora_Obtenido);
        }

        [TestMethod]
        public void Test4_ValidarPagoHora()
        {
            Empleado empleado = new Empleado
            {
                GradoAcademico = "Bachiller"
            };
            Contrato contrato = new Contrato
            {
                ValorHora = 10,
                Empleado = empleado

            };

            bool PagoHora_Esperado = false;
            bool PagoHora_Obtenido = contrato.ValidarPagoHora();
            Assert.AreEqual(PagoHora_Esperado, PagoHora_Obtenido);
        }

        [TestMethod]
        public void Test5_ValidarPagoHora()
        {
            Empleado empleado = new Empleado
            {
                GradoAcademico = "Bachiller"
            };
            Contrato contrato = new Contrato
            {
                ValorHora = 15,
                Empleado = empleado

            };

            bool PagoHora_Esperado = true;
            bool PagoHora_Obtenido = contrato.ValidarPagoHora();
            Assert.AreEqual(PagoHora_Esperado, PagoHora_Obtenido);
        }

        [TestMethod]
        public void Test6_ValidarPagoHora()
        {
            Empleado empleado = new Empleado
            {
                GradoAcademico = "Bachiller"
            };
            Contrato contrato = new Contrato
            {
                ValorHora = 21,
                Empleado = empleado

            };

            bool PagoHora_Esperado = false;
            bool PagoHora_Obtenido = contrato.ValidarPagoHora();
            Assert.AreEqual(PagoHora_Esperado, PagoHora_Obtenido);
        }

        [TestMethod]
        public void Test7_ValidarPagoHora()
        {
            Empleado empleado = new Empleado
            {
                GradoAcademico = "Profesional"
            };
            Contrato contrato = new Contrato
            {
                ValorHora = 20,
                Empleado = empleado

            };

            bool PagoHora_Esperado = false;
            bool PagoHora_Obtenido = contrato.ValidarPagoHora();
            Assert.AreEqual(PagoHora_Esperado, PagoHora_Obtenido);
        }

        [TestMethod]
        public void Test8_ValidarPagoHora()
        {
            Empleado empleado = new Empleado
            {
                GradoAcademico = "Profesional"
            };
            Contrato contrato = new Contrato
            {
                ValorHora = 25,
                Empleado = empleado

            };

            bool PagoHora_Esperado = true;
            bool PagoHora_Obtenido = contrato.ValidarPagoHora();
            Assert.AreEqual(PagoHora_Esperado, PagoHora_Obtenido);
        }

        [TestMethod]
        public void Test9_ValidarPagoHora()
        {
            Empleado empleado = new Empleado
            {
                GradoAcademico = "Profesional"
            };
            Contrato contrato = new Contrato
            {
                ValorHora = 31,
                Empleado = empleado

            };

            bool PagoHora_Esperado = false;
            bool PagoHora_Obtenido = contrato.ValidarPagoHora();
            Assert.AreEqual(PagoHora_Esperado, PagoHora_Obtenido);
        }

        public void Test10_ValidarPagoHora()
        {
            Empleado empleado = new Empleado
            {
                GradoAcademico = "Magister"
            };
            Contrato contrato = new Contrato
            {
                ValorHora = 30,
                Empleado = empleado

            };

            bool PagoHora_Esperado = false;
            bool PagoHora_Obtenido = contrato.ValidarPagoHora();
            Assert.AreEqual(PagoHora_Esperado, PagoHora_Obtenido);
        }

        [TestMethod]
        public void Test11_ValidarPagoHora()
        {
            Empleado empleado = new Empleado
            {
                GradoAcademico = "Magister"
            };
            Contrato contrato = new Contrato
            {
                ValorHora = 35,
                Empleado = empleado

            };

            bool PagoHora_Esperado = true;
            bool PagoHora_Obtenido = contrato.ValidarPagoHora();
            Assert.AreEqual(PagoHora_Esperado, PagoHora_Obtenido);
        }

        [TestMethod]
        public void Test12_ValidarPagoHora()
        {
            Empleado empleado = new Empleado
            {
                GradoAcademico = "Magister"
            };
            Contrato contrato = new Contrato
            {
                ValorHora = 41,
                Empleado = empleado

            };

            bool PagoHora_Esperado = false;
            bool PagoHora_Obtenido = contrato.ValidarPagoHora();
            Assert.AreEqual(PagoHora_Esperado, PagoHora_Obtenido);
        }

        public void Test13_ValidarPagoHora()
        {
            Empleado empleado = new Empleado
            {
                GradoAcademico = "Doctor"
            };
            Contrato contrato = new Contrato
            {
                ValorHora = 40,
                Empleado = empleado

            };

            bool PagoHora_Esperado = false;
            bool PagoHora_Obtenido = contrato.ValidarPagoHora();
            Assert.AreEqual(PagoHora_Esperado, PagoHora_Obtenido);
        }

        [TestMethod]
        public void Test14_ValidarPagoHora()
        {
            Empleado empleado = new Empleado
            {
                GradoAcademico = "Doctor"
            };
            Contrato contrato = new Contrato
            {
                ValorHora = 50,
                Empleado = empleado

            };

            bool PagoHora_Esperado = true;
            bool PagoHora_Obtenido = contrato.ValidarPagoHora();
            Assert.AreEqual(PagoHora_Esperado, PagoHora_Obtenido);
        }

        [TestMethod]
        public void Test15_ValidarPagoHora()
        {
            Empleado empleado = new Empleado
            {
                GradoAcademico = "Doctor"
            };
            Contrato contrato = new Contrato
            {
                ValorHora = 11,
                Empleado = empleado

            };

            bool PagoHora_Esperado = false;
            bool PagoHora_Obtenido = contrato.ValidarPagoHora();
            Assert.AreEqual(PagoHora_Esperado, PagoHora_Obtenido);
        }

        [TestMethod]
        public void Test16_ValidarPagoHora()
        {
            Empleado empleado = new Empleado
            {
                GradoAcademico = "Otro"
            };
            Contrato contrato = new Contrato
            {
                ValorHora = 11,
                Empleado = empleado

            };

            bool PagoHora_Esperado = false;
            bool PagoHora_Obtenido = contrato.ValidarPagoHora();
            Assert.AreEqual(PagoHora_Esperado, PagoHora_Obtenido);
        }

        [TestMethod]
        public void Test1_ValidarPeriodoContrato()
        {

            Contrato contrato = new Contrato
            {
                FechaInicio = DateTime.Parse("18/10/2019"),
                FechaFin = DateTime.Parse("18/10/2020"),

            };

            bool ValidarPeriodoContrato_Esperado = true;
            bool ValidarPeriodoContrato_Obtenido = contrato.ValidarPeriodoContrato();
            Assert.AreEqual(ValidarPeriodoContrato_Esperado, ValidarPeriodoContrato_Obtenido);
        }

        [TestMethod]
        public void Test2_ValidarPeriodoContrato()
        {

            Contrato contrato = new Contrato
            {
                FechaInicio = DateTime.Parse("18/10/2019"),
                FechaFin = DateTime.Parse("18/11/2020"),

            };

            bool ValidarPeriodoContrato_Esperado = false;
            bool ValidarPeriodoContrato_Obtenido = contrato.ValidarPeriodoContrato();
            Assert.AreEqual(ValidarPeriodoContrato_Esperado, ValidarPeriodoContrato_Obtenido);
        }

        [TestMethod]
        public void Test3_ValidarPeriodoContrato()
        {

            Contrato contrato = new Contrato
            {
                FechaInicio = DateTime.Parse("18/10/2019"),
                FechaFin = DateTime.Parse("18/12/2019"),

            };

            bool ValidarPeriodoContrato_Esperado = false;
            bool ValidarPeriodoContrato_Obtenido = contrato.ValidarPeriodoContrato();
            Assert.AreEqual(ValidarPeriodoContrato_Esperado, ValidarPeriodoContrato_Obtenido);
        }

        [TestMethod]
        public void Test4_ValidarPeriodoContrato()
        {

            Contrato contrato = new Contrato
            {
                FechaInicio = DateTime.Parse("18/10/2019"),
                FechaFin = DateTime.Parse("18/10/2019"),

            };

            bool ValidarPeriodoContrato_Esperado = false;
            bool ValidarPeriodoContrato_Obtenido = contrato.ValidarPeriodoContrato();
            Assert.AreEqual(ValidarPeriodoContrato_Esperado, ValidarPeriodoContrato_Obtenido);
        }
    }
}
