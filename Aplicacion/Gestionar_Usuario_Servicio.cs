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
    public class Gestionar_Usuario_Servicio:Singleton<Gestionar_Usuario_Servicio>
    {
        public bool IniciarSesion(Usuario usuario)
        {
            Usuario usuarioretorno = UsuarioDA.Instancia.IniciarSesion(usuario);
            if (usuarioretorno.Id_Usuario > 0) return true;
            else return false;
        }
    }
}
