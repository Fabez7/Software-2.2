using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.SqlClient;
using Microsoft.Practices.EnterpriseLibrary.Data.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;

namespace Persistencia
{
    public class AyudaDA
    {
        private static DatabaseProviderFactory factory = new DatabaseProviderFactory();
        //internal static String cadConexion = "DatabaseConnectionString";
        //internal static String cadConexion2 = "DatabaseConnectionString2";

        internal static Microsoft.Practices.EnterpriseLibrary.Data.Database db;
        internal static Microsoft.Practices.EnterpriseLibrary.Data.Database SetEnviroment(int tipoCadena)
        {
            FileConfigurationSource configSource = new FileConfigurationSource("data.config");
            DatabaseProviderFactory factory = new DatabaseProviderFactory(configSource);
            if (tipoCadena == 1) return factory.Create("DatabaseConnectionString"); else if (tipoCadena == 2) return factory.Create("DatabaseConnectionString2"); else if (tipoCadena == 3) return factory.Create("DatConStrSIGA"); else return factory.Create("DatConStrSIGAPRODUCCION");//return factory.Create(tipoCadena == 1 ? "DatabaseConnectionString" : "DatabaseConnectionString2");
            //return db = DatabaseFactory.CreateDatabase();
        }
        //private Database db = DatabaseSettings.GetDatabaseSettings();
        internal static IDataReader ExecuteReader(string CommandName, Int32 tipo, DbParameter[] param = null, DbTransaction transaction = null)
        {
            try
            {
                db = SetEnviroment(tipo);
                using (DbCommand cmd = db.GetStoredProcCommand(CommandName))
                {
                    if (param != null) cmd.Parameters.AddRange(param);
                    //db.AddInParameter(cmd, "dni", DbType.String,"41856906");
                    IDataReader dr = null;
                    if (transaction != null)
                    {
                        dr = db.ExecuteReader(cmd, transaction);
                    }
                    else
                    {
                        dr = db.ExecuteReader(cmd);
                    }
                    cmd.Dispose();
                    return dr;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error Inesperado=>" + ex.Message, ex);
            }
        }

        internal static DataSet ExecuteDataSet(string CommandName, Int32 tipo, DbParameter[] param = null, DbTransaction transaction = null)
        {
            try
            {
                db = SetEnviroment(tipo);
                using (DbCommand cmd = db.GetStoredProcCommand(CommandName))
                {
                    if (param != null) cmd.Parameters.AddRange(param);
                    //db.AddInParameter(cmd, "dni", DbType.String,"41856906");
                    DataSet ds = null;
                    if (transaction != null)
                    {
                        ds = db.ExecuteDataSet(cmd, transaction);
                    }
                    else
                    {
                        ds = db.ExecuteDataSet(cmd);
                    }
                    cmd.Dispose();
                    return ds;
                }

            }
            catch (Exception ex)
            {

                throw new Exception("Error Inesperado=>" + ex.Message, ex);
            }
        }


        internal static Int32 ExecuteNonQuery(String CommandName, Int32 tipo, DbParameter[] param = null, DbTransaction transaction = null)
        {
            try
            {
                db = SetEnviroment(tipo);
                Int32 result = 0;
                using (DbCommand cmd = db.GetStoredProcCommand(CommandName))
                {
                    if (param != null) cmd.Parameters.AddRange(param);
                    if (transaction != null)
                    {
                        result = db.ExecuteNonQuery(cmd, transaction);
                    }
                    else
                    {
                        result = db.ExecuteNonQuery(cmd);
                    }

                    return result;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error Inesperado =>" + ex.Message, ex);
            }
        }


        internal static DbParameter AddParameter(String parameterName, Object value, ParameterDirection direction = ParameterDirection.Input)
        {
            SqlParameter parameter = new SqlParameter
            {
                ParameterName = parameterName,
                Value = value,
                Direction = direction
            };
            return parameter;
        }


        internal static DbParameter AddParameter(String parameterName, Object value, DbType TipoDato, ParameterDirection direction = ParameterDirection.Input)
        {
            SqlParameter parameter = new SqlParameter
            {
                ParameterName = parameterName,
                Value = value,
                Direction = direction,
                DbType = TipoDato
            };
            return parameter;
        }

        internal static Int32 ExecuteNonQueryOut(String CommandName, Int32 tipo, DbParameter[] param, ref DbCommand cmdx, ref Database dbx, DbTransaction transaction = null) //out List<DbParameter> outputParameters
        {
            try
            {

                // DatabaseProviderFactory factory = new DatabaseProviderFactory();
                //Database db = factory.Create(tipo == 1 ? cadConexion : cadConexion2);
                db = SetEnviroment(tipo);
                Int32 result = 0;
                using (DbCommand cmd = db.GetStoredProcCommand(CommandName))
                {
                    cmd.Parameters.AddRange(param);
                    if (transaction != null)
                    {
                        result = db.ExecuteNonQuery(cmd, transaction);
                    }
                    else
                    {
                        result = db.ExecuteNonQuery(cmd);
                    }

                    dbx = db;
                    cmdx = cmd;
                    return result;

                }


            }
            catch (Exception ex)
            {
                throw new Exception("Error Inesperado =>" + ex.Message, ex);

            }
        }

        internal static Int32 ExecuteNonQueryOutWithOutDB(String CommandName, DbParameter[] param, ref DbCommand cmdx, ref Database db, DbTransaction transaction = null) //out List<DbParameter> outputParameters
        {
            try
            {
                Int32 result = 0;
                using (DbCommand cmd = db.GetStoredProcCommand(CommandName))
                {
                    cmd.Parameters.AddRange(param);
                    if (transaction != null)
                    {
                        result = db.ExecuteNonQuery(cmd, transaction);
                    }
                    else
                    {
                        result = db.ExecuteNonQuery(cmd);
                    }

                    cmdx = cmd;
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error Inesperado =>" + ex.Message, ex);

            }
        }

        internal static Int32 ExecuteNonQueryOutWithOutDBX(String CommandName, DbParameter[] param, ref DbCommand cmdx, ref Database dbx, DbTransaction transaction = null) //out List<DbParameter> outputParameters
        {
            try
            {
                Int32 result = 0;
                using (DbCommand cmd = db.GetStoredProcCommand(CommandName))
                {
                    cmd.Parameters.AddRange(param);
                    if (transaction != null)
                    {
                        result = db.ExecuteNonQuery(cmd, transaction);
                    }
                    else
                    {
                        result = db.ExecuteNonQuery(cmd);
                    }
                    dbx = db;
                    cmdx = cmd;
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error Inesperado =>" + ex.Message, ex);

            }
        }
        internal static String ConvertirFecha(DateTime fecha)
        {
            string stfecha = fecha.Day.ToString() + "/" + fecha.Month.ToString() + "/" + fecha.Year.ToString();
            return stfecha;
        }

    }
    public enum EnumCadenaConexion : int
    {
        BDGRLL = 1,
        SIGA_DEMO = 3,
        SIGA_PRODUCCION = 4
    }
}
