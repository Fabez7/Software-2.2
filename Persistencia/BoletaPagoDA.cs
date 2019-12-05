using Dominio;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Persistencia.Singleton;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    public class BoletaPagoDA:Singleton<BoletaPagoDA>
    {

        public void RegistrarBoletaPago(BoletaPago boletaPago,PeriodoPago periodoPago, Database DB, DbTransaction Trans)
        {
            try
            {
                //throw new Exception("Error en los datos. Error guardando al cliente.");
                DbParameter[] parameters = new DbParameter[]
                {
                AyudaDA.AddParameter("@FechaPago", boletaPago.FechaPago),
                AyudaDA.AddParameter("@TotalHoras",boletaPago.TotalHoras),
                AyudaDA.AddParameter("@ValorHora",boletaPago.ValorHora),
                AyudaDA.AddParameter("@AsignacionFamiliar",boletaPago.AsignacionFamiliar),
                AyudaDA.AddParameter("@PorcentajeAFP",boletaPago.PorcentajeAFP),
                AyudaDA.AddParameter("@Id_PerdiodoPago",periodoPago.Id_PeriodoPago),
                AyudaDA.AddParameter("@Id_Conceptos",boletaPago.Conceptos.Id_Conceptos),
                AyudaDA.AddParameter("@Id_Contrato",boletaPago.Contrato.Id_Contrato),
                };
                DbCommand cmdDETC = null;
                AyudaDA.ExecuteNonQueryOutWithOutDB("REGISTRAR_BOLETA", parameters, ref cmdDETC, ref DB, Trans);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
