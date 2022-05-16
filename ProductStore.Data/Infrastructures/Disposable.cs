using System;
using System.Collections.Generic;
using System.Text;

namespace ProductStore.Data.Infrastructures
{
    public class Disposable : IDisposable
    {
        private bool disposedValue; //initialiser à false ; permet de détecter les appels redondants 


        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue) //!false = true ;l'objet n"a pas été srupprimé
            {
                if (disposing)
                {
                    DisposeCore();
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
         ~Disposable()
         {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: false);
        }
        protected virtual void DisposeCore()
        {
            //insert code
        }

    }
}
