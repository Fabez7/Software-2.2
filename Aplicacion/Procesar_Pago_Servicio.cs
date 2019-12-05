using Dominio;
using Persistencia;
using Persistencia.Singleton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion
{
    public class Procesar_Pago_Servicio : Singleton<Procesar_Pago_Servicio>
    {
        public PeriodoPago ObtenerPeriodo()
        {
            PeriodoPago periodo = new PeriodoPago();
            periodo = PeriodoPagoDA.Instancia.ObtenerPeriodo();
            PeriodoPago pe = new PeriodoPago();

            if (pe.ValidarPeriodoPago())
                pe = periodo;

            return pe;
        }

        public String ProcesarPago(PeriodoPago periodoPago, ref List<BoletaPago> boletas)
        {
            if (periodoPago.ValidarPeriodoPago())
            {
                List<Contrato> contratos = ContratoDA.Instancia.ListarContrato();
                String fechatem = System.DateTime.Now.ToShortTimeString();
                DateTime fechapago = DateTime.Parse(fechatem);
                foreach (Contrato contrato in contratos)
                {
                    if (contrato.ObtenerVigencia())
                    {
                        BoletaPago boletaPago = new BoletaPago();
                        contrato.AFP = AFPDA.Instancia.ObtenerAFP(contrato.AFP.Id_AFP);
                        boletaPago.Contrato = contrato;
                        boletaPago.PeriodoPago = periodoPago;
                        contrato.Empleado = EmpleadoDA.Instancia.BuscarEmpleado(contrato.Empleado.Id_Empleado);
                        boletaPago.Conceptos = ConceptosDA.Instancia.ObtenerConceptos(contrato.Id_Contrato, periodoPago.Id_PeriodoPago);
                        boletaPago.PorcentajeAFP = contrato.AFP.Porcentaje;
                        boletaPago.TotalHoras = boletaPago.CalcularTotalHoras();
                        boletaPago.ValorHora = contrato.ValorHora;
                        boletaPago.AsignacionFamiliar = boletaPago.CalcularAsignacionFamiliar();
                        boletaPago.FechaPago = fechapago;
                        boletas.Add(boletaPago);
                    }
                }
                if (boletas.Count() == 0)
                {
                    return "NC";
                }
                else
                {
                    periodoPago.Estado = "Procesado";
                    if (PeriodoPagoDA.Instancia.ProcesarPeriodo(periodoPago, boletas)) return "OK";
                    else return "SQL";
                }

            }
            return "R01";
        }
    }
}
