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
    
    
    public class Gestionar_Contrato_Servicio:Singleton<Gestionar_Contrato_Servicio>
    {
        
        public Boolean ValidarVigencia(Int32 Id_Empleado)
        {
            Contrato contratoAnterior = ContratoDA.Instancia.ObtenerFechaFin(Id_Empleado,0);
            return contratoAnterior.ObtenerVigencia();
        }

        public String RegistrarContrato(Contrato contrato,Int32 Id_AFP, Int32 Id_Empleado,Int32 Id_Cargo)
        {
            Contrato contraAnterior = ContratoDA.Instancia.ObtenerContrato(Id_Empleado);
            contrato.Empleado = EmpleadoDA.Instancia.BuscarEmpleado(Id_Empleado);
            if (contraAnterior == null || contrato.ValidarFechaContrato(contraAnterior.FechaFin))
            {
                if (contrato.ValidarPeriodoContrato())
                {
                    if (contrato.ValidarHoraSemana())
                    {
                        if (contrato.ValidarPagoHora())
                        {
                            if (ContratoDA.Instancia.CrearContrato(contrato, Id_Cargo, Id_AFP, Id_Empleado)) return "OK";
                            else return "SQL";
                        }
                        else return "R05";
                    }
                    return "R04";
                }
                return "R03";
            }
            else return "R02";
            
        }

        public String ActualizarContrato(Contrato contrato, Int32 Id_AFP, Int32 Id_Empleado, Int32 Id_Cargo)
        {
            Contrato contraAnterior = ContratoDA.Instancia.ObtenerFechaFin(Id_Empleado,contrato.Id_Contrato);
            contrato.Empleado = EmpleadoDA.Instancia.BuscarEmpleado(Id_Empleado);
            if (contraAnterior == null || contrato.ValidarFechaContrato(contraAnterior.FechaFin))
            {
                if (contrato.ValidarPeriodoContrato())
                {
                    if (contrato.ValidarHoraSemana())
                    {
                        if (contrato.ValidarPagoHora())
                        {
                            if (ContratoDA.Instancia.ActualizarContrato(contrato, Id_Cargo, Id_AFP, Id_Empleado)) return "OK";
                            else return "SQL";
                        }
                        else return "R05";
                    }
                    return "R04";
                }
                return "R03";
            }
            else return "R02";

        }

        public Contrato ObtenerContrato(Int32 Id_Empleado)
        {
            Contrato contrato = new Contrato();
            contrato =  ContratoDA.Instancia.ObtenerContrato(Id_Empleado);
            if (contrato.ObtenerVigencia()) return contrato;
            else return new Contrato();
        }
        public Int32 AnularContrato(Int32 Id_Contrato)
        {
            Contrato contrato = new Contrato
            {
                Id_Contrato = Id_Contrato,
                Anulado = true
            };
            if (ContratoDA.Instancia.AnularContrato(contrato)) return 1;
            else return 0;
        }
    }
}
