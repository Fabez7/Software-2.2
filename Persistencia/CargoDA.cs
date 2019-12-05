
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
    public class CargoDA : Singleton<CargoDA>
    {
        public List<Cargo> ListarCargo()
        {
            try
            {
                List<Cargo> listaCargo = new List<Cargo>();

                using (IDataReader dr = AyudaDA.ExecuteReader("LISTAR_CARGO", 1))// Por favor leer el estandar de Nomenclatura de Base de Datos
                {
                    while (dr.Read())
                    {

                        Cargo cargo = new Cargo
                        {
                            Id_Cargo = dr.GetInt32(dr.GetOrdinal("Id_Cargo")),
                            Nombre = dr.IsDBNull(dr.GetOrdinal("Nombre")) ? default(string) : dr.GetString(dr.GetOrdinal("Nombre"))
                        };
                        listaCargo.Add(cargo);
                    };
                }
                return listaCargo;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}

