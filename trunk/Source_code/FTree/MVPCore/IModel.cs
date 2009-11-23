using System;
using System.Text;
using System.Collections;
using System.ComponentModel;
using System.Collections.Generic;
using FTree.Common;

namespace MVPCore
{
    public interface IModel : INotifyPropertyChanged, IValidatable
    {
		bool IsExists(object id);

        bool Add(object dataTransferObject);
        
        bool Delete(object id);
		
		bool Update(object dataTransferObject);

		object GetObject(object id);
		
        IList<object> GetData(string dataName);
    }
}
