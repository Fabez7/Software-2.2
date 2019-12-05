using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Usuario:EntidadBase
    {
        public Int32 Id_Usuario { get; set; }
        public String Nombre { get; set; }
        public String Clave { get; set; }
    }
}
