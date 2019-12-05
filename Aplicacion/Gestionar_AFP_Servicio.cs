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
    public class Gestionar_AFP_Servicio : Singleton<Gestionar_AFP_Servicio>
    {
        public List<AFP> ListarAFP()
        {
            return AFPDA.Instancia.ListarAFP();
        }
    }
}