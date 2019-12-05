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
    public class EmpleadoDA:Singleton<EmpleadoDA>
    {
        public Empleado BuscarEmpleado(String DNI)
        {
            try
            {
                Empleado empleado = new Empleado();
                DbParameter[] parameters = new DbParameter[]{
                AyudaDA.AddParameter("@DNI",DNI)
                };
                using (IDataReader dr = AyudaDA.ExecuteReader("BUSCAR_EMPLEADO", 1, parameters))// Por favor leer el estandar de Nomenclatura de Base de Datos
                {
                    while (dr.Read())
                    {
                        empleado.Id_Empleado = dr.GetInt32(dr.GetOrdinal("Id_Empleado"));
                        empleado.Nombre = dr.IsDBNull(dr.GetOrdinal("Nombre")) ? default(string) : dr.GetString(dr.GetOrdinal("Nombre"));
                        empleado.Direccion = dr.IsDBNull(dr.GetOrdinal("Direccion")) ? default(string) : dr.GetString(dr.GetOrdinal("Direccion"));
                        empleado.Telefono = dr.IsDBNull(dr.GetOrdinal("Telefono")) ? default(string) : dr.GetString(dr.GetOrdinal("Telefono"));
                        empleado.FechaNacimiento = dr.IsDBNull(dr.GetOrdinal("FechaNacimiento")) ? default(DateTime) : dr.GetDateTime(dr.GetOrdinal("FechaNacimiento"));
                        empleado.EstadoCivil = dr.IsDBNull(dr.GetOrdinal("EstadoCivil")) ? default(string) : dr.GetString(dr.GetOrdinal("EstadoCivil"));
                        empleado.GradoAcademico = dr.IsDBNull(dr.GetOrdinal("GradoAcademico")) ? default(string) : dr.GetString(dr.GetOrdinal("GradoAcademico"));

                    };
                }
                return empleado;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Empleado BuscarEmpleado(Int32 Id_Empleado)
        {
            try
            {
                Empleado empleado = new Empleado();
                DbParameter[] parameters = new DbParameter[]{
                AyudaDA.AddParameter("@Id_Empleado",Id_Empleado)
                };
                using (IDataReader dr = AyudaDA.ExecuteReader("OBTENER_EMPLEADO", 1, parameters))// Por favor leer el estandar de Nomenclatura de Base de Datos
                {
                    while (dr.Read())
                    {
                        empleado.Id_Empleado = dr.GetInt32(dr.GetOrdinal("Id_Empleado"));
                        empleado.Nombre = dr.IsDBNull(dr.GetOrdinal("Nombre")) ? default(string) : dr.GetString(dr.GetOrdinal("Nombre"));
                        empleado.DNI = dr.IsDBNull(dr.GetOrdinal("DNI")) ? default(string) : dr.GetString(dr.GetOrdinal("DNI"));
                        empleado.Direccion = dr.IsDBNull(dr.GetOrdinal("Direccion")) ? default(string) : dr.GetString(dr.GetOrdinal("Direccion"));
                        empleado.Telefono = dr.IsDBNull(dr.GetOrdinal("Telefono")) ? default(string) : dr.GetString(dr.GetOrdinal("Telefono"));
                        empleado.FechaNacimiento = dr.IsDBNull(dr.GetOrdinal("FechaNacimiento")) ? default(DateTime) : dr.GetDateTime(dr.GetOrdinal("FechaNacimiento"));
                        empleado.EstadoCivil = dr.IsDBNull(dr.GetOrdinal("EstadoCivil")) ? default(string) : dr.GetString(dr.GetOrdinal("EstadoCivil"));
                        empleado.GradoAcademico = dr.IsDBNull(dr.GetOrdinal("GradoAcademico")) ? default(string) : dr.GetString(dr.GetOrdinal("GradoAcademico"));

                    };
                }
                return empleado;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
