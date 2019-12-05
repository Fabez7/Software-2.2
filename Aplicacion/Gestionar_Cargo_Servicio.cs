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
    public class Gestionar_Cargo_Servicio:Singleton<Gestionar_Cargo_Servicio>
    {
        public List<Cargo> ListarCargo()
        {
            return CargoDA.Instancia.ListarCargo();
        }
    }
}
