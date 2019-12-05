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
    public class UsuarioDA:Singleton<UsuarioDA>
    {
        public Usuario IniciarSesion(Usuario usuario)
        {
            try
            {
                Usuario usuariotretormo = new Usuario();
                DbParameter[] parameters = new DbParameter[]{
                AyudaDA.AddParameter("@Nombre",usuario.Nombre),
                AyudaDA.AddParameter("@Clave",usuario.Clave)
                };
                using (IDataReader dr = AyudaDA.ExecuteReader("ObtenerUsuario", 1, parameters))// Por favor leer el estandar de Nomenclatura de Base de Datos
                {
                    while (dr.Read())
                    {
                        usuariotretormo.Id_Usuario = dr.GetInt32(dr.GetOrdinal("Id_Usuario"));
                        usuariotretormo.Nombre = dr.IsDBNull(dr.GetOrdinal("Nombre")) ? default(string) : dr.GetString(dr.GetOrdinal("Nombre"));
                        usuariotretormo.Clave = dr.IsDBNull(dr.GetOrdinal("Clave")) ? default(string) : dr.GetString(dr.GetOrdinal("Clave"));
                    };
                }
                return usuariotretormo;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
