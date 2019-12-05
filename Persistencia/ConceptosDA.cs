using Dominio;
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
    public class ConceptosDA : Singleton<ConceptosDA>
    {
        public Conceptos ObtenerConceptos(Int32 Id_Contrato, Int32 Id_PeriodoPago)
        {
            try
            {
                Conceptos conceptos = new Conceptos();
                DbParameter[] parameters = new DbParameter[]{
                AyudaDA.AddParameter("@Id_Contrato",Id_Contrato),
                AyudaDA.AddParameter("@Id_PeriodoPago",Id_PeriodoPago)
                };
                using (IDataReader dr = AyudaDA.ExecuteReader("OBTENER_CONCEPTOS", 1, parameters))// Por favor leer el estandar de Nomenclatura de Base de Datos
                {
                    while (dr.Read())
                    {
                        conceptos.Id_Conceptos = dr.GetInt32(dr.GetOrdinal("Id_Conceptos"));
                        conceptos.Adelanto = dr.IsDBNull(dr.GetOrdinal("Adelantos")) ? default(decimal) : dr.GetDecimal(dr.GetOrdinal("Adelantos"));
                        conceptos.HorasAusentes = dr.IsDBNull(dr.GetOrdinal("HorasAusentes")) ? default(decimal) : dr.GetDecimal(dr.GetOrdinal("HorasAusentes"));
                        conceptos.HorasExtras = dr.IsDBNull(dr.GetOrdinal("HorasExtras")) ? default(decimal) : dr.GetDecimal(dr.GetOrdinal("HorasExtras"));
                        conceptos.OtrosDescuentos = dr.IsDBNull(dr.GetOrdinal("OtrosDescuentos")) ? default(decimal) : dr.GetDecimal(dr.GetOrdinal("OtrosDescuentos"));
                        conceptos.OtrosIngresos = dr.IsDBNull(dr.GetOrdinal("OtrosIngresos")) ? default(decimal) : dr.GetDecimal(dr.GetOrdinal("OtrosIngresos"));
                        conceptos.Reintegros = dr.IsDBNull(dr.GetOrdinal("Reintegros")) ? default(decimal) : dr.GetDecimal(dr.GetOrdinal("Reintegros"));
                    };
                }
                return conceptos;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
