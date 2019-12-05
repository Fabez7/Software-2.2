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
    public class ContratoDA : Singleton<ContratoDA>
    {


        public Boolean CrearContrato(Contrato contrato,Int32 Id_Cargo,Int32 Id_AFP, Int32 Id_Empleado)
        {
            try
            {
                //throw new Exception("Error en los datos. Error guardando al cliente.");
                DbParameter[] parameters = new DbParameter[]
                {
                AyudaDA.AddParameter("@FechaInicio", contrato.FechaInicio),
                AyudaDA.AddParameter("@FechaFin",contrato.FechaFin),
                AyudaDA.AddParameter("@Id_AFP",Id_AFP),
                AyudaDA.AddParameter("@Id_Cargo",Id_Cargo),
                AyudaDA.AddParameter("@Id_Empleado",Id_Empleado),
                AyudaDA.AddParameter("@AsignacionFamiliar",contrato.AsignacionFamiliar),
                AyudaDA.AddParameter("@HorasContratadas",contrato.HorasContratadas),
                AyudaDA.AddParameter("@ValorHora",contrato.ValorHora)
            };
                int codigo = AyudaDA.ExecuteNonQuery("REGISTRAR_CONTRATO", 1, parameters);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public Contrato ObtenerContrato(Int32 Id_Empleado)
        {
            try
            {
                Contrato contrato = new Contrato();
                DbParameter[] parameters = new DbParameter[]{
                AyudaDA.AddParameter("@Id_Empleado",Id_Empleado)
                };
                using (IDataReader dr = AyudaDA.ExecuteReader("OBTENER_CONTRATO", 1, parameters))// Por favor leer el estandar de Nomenclatura de Base de Datos
                {
                    while (dr.Read())
                    {
                        contrato.Id_Contrato = dr.GetInt32(dr.GetOrdinal("Id_Contrato"));
                        contrato.FechaInicio = dr.IsDBNull(dr.GetOrdinal("FechaInicio")) ? default(DateTime) : dr.GetDateTime(dr.GetOrdinal("FechaInicio"));
                        contrato.FechaFin = dr.IsDBNull(dr.GetOrdinal("FechaFin")) ? default(DateTime) : dr.GetDateTime(dr.GetOrdinal("FechaFin"));
                        contrato.AsignacionFamiliar = dr.IsDBNull(dr.GetOrdinal("AsignacionFamiliar")) ? default(bool) : dr.GetBoolean(dr.GetOrdinal("AsignacionFamiliar"));
                        contrato.HorasContratadas = dr.IsDBNull(dr.GetOrdinal("HorasContratadas")) ? default(int) : dr.GetInt32(dr.GetOrdinal("HorasContratadas"));
                        contrato.ValorHora = dr.IsDBNull(dr.GetOrdinal("ValorHora")) ? default(decimal) : dr.GetDecimal(dr.GetOrdinal("ValorHora"));
                        contrato.Anulado = Convert.ToBoolean(dr["Anulado"]);
                        AFP afp = new AFP
                        {
                            Id_AFP = dr.GetInt32(dr.GetOrdinal("Id_AFP")),
                            //Porcentaje = dr.IsDBNull(dr.GetOrdinal("Porcentaje")) ? default(decimal) : dr.GetDecimal(dr.GetOrdinal("Porcentaje"))

                        };
                        contrato.AFP = afp;
                        Cargo cargo = new Cargo
                        {
                            Id_Cargo = dr.GetInt32(dr.GetOrdinal("Id_Cargo"))
                        };
                        contrato.Cargo = cargo;
                    };
                }
                return contrato;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Contrato> ListarContrato()
        {
            try
            {
                List<Contrato> contratos = new List<Contrato>();
                using (IDataReader dr = AyudaDA.ExecuteReader("LISTAR_CONTRATO", 1))// Por favor leer el estandar de Nomenclatura de Base de Datos
                {                    
                    while (dr.Read())
                    {
                        Contrato contrato = new Contrato();
                        contrato.Id_Contrato = dr.GetInt32(dr.GetOrdinal("Id_Contrato"));
                        contrato.FechaInicio = dr.IsDBNull(dr.GetOrdinal("FechaInicio")) ? default(DateTime) : dr.GetDateTime(dr.GetOrdinal("FechaInicio"));
                        contrato.FechaFin = dr.IsDBNull(dr.GetOrdinal("FechaFin")) ? default(DateTime) : dr.GetDateTime(dr.GetOrdinal("FechaFin"));
                        //if (dr.GetInt32(dr.GetOrdinal("AsignacionFamiliar")) == 1) contrato.AsignacionFamiliar = true; else contrato.AsignacionFamiliar = false;
                        contrato.AsignacionFamiliar = dr.IsDBNull(dr.GetOrdinal("AsignacionFamiliar")) ? default(bool) : dr.GetBoolean(dr.GetOrdinal("AsignacionFamiliar"));
                        contrato.HorasContratadas = dr.IsDBNull(dr.GetOrdinal("HorasContratadas")) ? default(int) : dr.GetInt32(dr.GetOrdinal("HorasContratadas"));
                        contrato.ValorHora = dr.IsDBNull(dr.GetOrdinal("ValorHora")) ? default(decimal) : dr.GetDecimal(dr.GetOrdinal("ValorHora"));
                        AFP afp = new AFP
                        {
                            Id_AFP = dr.GetInt32(dr.GetOrdinal("Id_AFP")),
                            //Porcentaje = dr.IsDBNull(dr.GetOrdinal("Porcentaje")) ? default(decimal) : dr.GetDecimal(dr.GetOrdinal("Porcentaje"))

                        };
                        contrato.AFP = afp;
                        Cargo cargo = new Cargo
                        {
                            Id_Cargo = dr.GetInt32(dr.GetOrdinal("Id_Cargo"))
                        };
                        Empleado empleado = new Empleado
                        {
                            Id_Empleado = dr.GetInt32(dr.GetOrdinal("Id_Empleado"))
                        };
                        contrato.Cargo = cargo;
                        contrato.Empleado = empleado;
                        contratos.Add(contrato);
                    };
                }
                return contratos;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Contrato ObtenerFechaFin(Int32 Id_Empleado, Int32 Id_Contrato)
        {
            try
            {
                Contrato contrato = new Contrato();
                DbParameter[] parameters = new DbParameter[]{
                AyudaDA.AddParameter("@Id_Empleado",Id_Empleado),
                AyudaDA.AddParameter("@Id_Contrato",Id_Contrato),
                };
                using (IDataReader dr = AyudaDA.ExecuteReader("OBTENER_CONTRATOFECHAFIN", 1, parameters))// Por favor leer el estandar de Nomenclatura de Base de Datos
                {
                    while (dr.Read())
                    {
                        contrato.Id_Contrato = dr.GetInt32(dr.GetOrdinal("Id_Contrato"));
                        contrato.FechaFin = dr.IsDBNull(dr.GetOrdinal("FechaFin")) ? default(DateTime) : dr.GetDateTime(dr.GetOrdinal("FechaFin"));
                    };
                }
                return contrato;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Boolean ActualizarContrato(Contrato contrato,Int32 Id_Cargo,Int32 Id_AFP,Int32 Id_Empleado)
        {
            try
            {
                //throw new Exception("Error en los datos. Error guardando al cliente.");
                DbParameter[] parameters = new DbParameter[]
                {
                AyudaDA.AddParameter("@Id_Contrato",contrato.Id_Contrato),
                AyudaDA.AddParameter("@FechaInicio", contrato.FechaInicio),
                AyudaDA.AddParameter("@FechaFin",contrato.FechaFin),
                AyudaDA.AddParameter("@Id_AFP",Id_AFP),
                AyudaDA.AddParameter("@Id_Cargo",Id_Cargo),
                AyudaDA.AddParameter("@AsignacionFamiliar",contrato.AsignacionFamiliar),
                AyudaDA.AddParameter("@HorasContratadas",contrato.HorasContratadas),
                AyudaDA.AddParameter("@ValorHora",contrato.ValorHora)
            };
                int codigo = AyudaDA.ExecuteNonQuery("ACTUALIZAR_CONTRATO", 1, parameters);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Boolean AnularContrato(Contrato contrato)
        {
            try
            {
                //throw new Exception("Error en los datos. Error guardando al cliente.");
                DbParameter[] parameters = new DbParameter[]
                {
                AyudaDA.AddParameter("@Id_Contrato", contrato.Id_Contrato),
                AyudaDA.AddParameter("@Anulado", contrato.Anulado)
            };
                int codigo = AyudaDA.ExecuteNonQuery("ANULAR_CONTRATO", 1, parameters);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
