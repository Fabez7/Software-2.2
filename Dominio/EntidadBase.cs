using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{

    public abstract class EntidadBase : IDisposable
    {
        #region Miembros de IDisposable

        public void Dispose() => GC.Collect();

        #endregion
    }
}
