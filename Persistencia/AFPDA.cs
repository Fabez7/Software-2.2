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
    public class AFPDA : Singleton<AFPDA>
    {
        public List<AFP> ListarAFP()
        {
            try
            {
                List<AFP> listaAFP = new List<AFP>();

                using (IDataReader dr = AyudaDA.ExecuteReader("LISTAR_AFP", 1))// Por favor leer el estandar de Nomenclatura de Base de Datos
                {
                    while (dr.Read())
                    {

                        AFP cargo = new AFP
                        {
                            Id_AFP = dr.GetInt32(dr.GetOrdinal("Id_AFP")),
                            Nombre = dr.IsDBNull(dr.GetOrdinal("Nombre")) ? default(string) : dr.GetString(dr.GetOrdinal("Nombre"))
                        };
                        listaAFP.Add(cargo);
                    };
                }
                return listaAFP;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public AFP ObtenerAFP(Int32 Id_AFP)
        {
            try
            {
                AFP aFP = new AFP();
                DbParameter[] parameters = new DbParameter[]{
                AyudaDA.AddParameter("@Id_AFP",Id_AFP)
                };
                using (IDataReader dr = AyudaDA.ExecuteReader("OBTENER_AFP", 1, parameters))// Por favor leer el estandar de Nomenclatura de Base de Datos
                {
                    while (dr.Read())
                    {
                        aFP.Id_AFP = dr.GetInt32(dr.GetOrdinal("Id_AFP"));
                        aFP.Nombre = dr.IsDBNull(dr.GetOrdinal("Nombre")) ? default(string) : dr.GetString(dr.GetOrdinal("Nombre"));
                        aFP.Porcentaje = dr.IsDBNull(dr.GetOrdinal("Porcentaje")) ? default(decimal) : dr.GetDecimal(dr.GetOrdinal("Porcentaje"));
                    };
                }
                return aFP;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}