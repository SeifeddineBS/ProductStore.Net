using System;
using System.Collections.Generic;
using System.Text;

namespace ProductStore.Data.Infrastructures
{
    public class DataBaseFactory : Disposable, IDataBaseFactory
    {
        private PSContext dataContext;
        public PSContext DataContext{get { return dataContext; }}
        public DataBaseFactory() 
        { 
            dataContext = new PSContext();
        }
        protected override void DisposeCore()
        {
            if (dataContext != null)
                dataContext.Dispose(); // libérer l'espace mémoire occuppé par le context
        }
    }
}
