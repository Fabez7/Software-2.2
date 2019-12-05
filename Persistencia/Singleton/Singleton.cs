using System;
using System.Threading;
namespace Persistencia.Singleton
{
    public abstract class Singleton<T> where T : class, new()
    {
        private static T _instancia;
        private static readonly Mutex _mutex = new Mutex();
        public static T Instancia
        {
            get
            {
                _mutex.WaitOne();
                if (_instancia == null)
                {
                    _instancia = new T();
                }
                _mutex.ReleaseMutex();
                return _instancia;
            }
        }
    }
}
