using System;
using System.Collections.Generic;
using System.Text;
using MVPCore;

namespace FTree.Model
{
    public class MSSqlSeverDatabase : IDatabase
    {
        #region IDatabase Members

        public string ConnectionString
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public bool OpenConnection()
        {
            throw new NotImplementedException();
        }

        public bool CloseConnection()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IModel Members

        public bool IsExists(object id)
        {
            throw new NotImplementedException();
        }

        public bool Add(object dataTransferObject)
        {
            throw new NotImplementedException();
        }

        public bool Delete(object id)
        {
            throw new NotImplementedException();
        }

        public bool Update(object dataTransferObject)
        {
            throw new NotImplementedException();
        }

        public object GetObject(object id)
        {
            throw new NotImplementedException();
        }

        public IList<object> GetData(string dataName)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region INotifyPropertyChanged Members

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region IValidatable Members

        public bool Validate()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
