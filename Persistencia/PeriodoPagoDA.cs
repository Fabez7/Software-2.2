using Dominio;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Persistencia.Singleton;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    public class PeriodoPagoDA:Singleton<PeriodoPagoDA>
    {
        public PeriodoPago ObtenerPeriodo()
        {
            PeriodoPago periodo = new PeriodoPago();
            try
            {
                
                using (IDataReader dr = AyudaDA.ExecuteReader("OBTENER_PERIODOPAGO", 1))// Por favor leer el estandar de Nomenclatura de Base de Datos
                {
                    while (dr.Read())
                    {
                        periodo.Id_PeriodoPago = dr.GetInt32(dr.GetOrdinal("Id_PeriodoPago"));
                        periodo.FechaInicio = dr.IsDBNull(dr.GetOrdinal("FechaInicio")) ? default(DateTime) : dr.GetDateTime(dr.GetOrdinal("FechaInicio"));
                        periodo.FechaFin = dr.IsDBNull(dr.GetOrdinal("FechaFin")) ? default(DateTime) : dr.GetDateTime(dr.GetOrdinal("FechaFin"));
                    };
                }
                return periodo;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public Boolean ProcesarPeriodo(PeriodoPago periodoPago, List<BoletaPago> lstboletaPagos)
        {
            Boolean correcto = false;
            try
            {
                Database DB = AyudaDA.SetEnviroment(1);
                using (var conn = DB.CreateConnection())
                {
                    conn.Open();
                    using (DbTransaction Trans = conn.BeginTransaction())
                    {
                        try
                        {



                            foreach (BoletaPago boletaPago in lstboletaPagos)
                            {
                                BoletaPagoDA.Instancia.RegistrarBoletaPago(boletaPago,periodoPago, DB, Trans);
                            }
                            //throw new Exception("Error en los datos. Error guardando al cliente.");
                            DbParameter[] parameters = new DbParameter[]
                            {
                
                            AyudaDA.AddParameter("@Id_PeriodoPago", periodoPago.Id_PeriodoPago),
                            AyudaDA.AddParameter("@Estado", periodoPago.Estado)
                            };
                            DbCommand cmdCom = null;
                            AyudaDA.ExecuteNonQueryOutWithOutDB("PROCESAR_PAGO", parameters, ref cmdCom, ref DB, Trans);
                            //Valida Telefono
                            Trans.Commit();
                            correcto = true;
                        }
                        catch (Exception ex)
                        {
                            correcto = false;
                            Trans.Rollback();
                            throw ex;
                        }
                    }

                }
            }
            catch (Exception)
            {
                correcto = false;
                throw;
            }
            return correcto;
        }
    }
}
