using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class AFP:EntidadBase
    {
        public int Id_AFP { get; set; }
        public String Nombre { get; set; }
        public Decimal Porcentaje { get; set; }
    }
}
