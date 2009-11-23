using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace MVPCore
{
    public interface IDatabase : IModel
    {
		string ConnectionString{get; set;}
		
		bool OpenConnection();
		
		bool CloseConnection();
    }
}