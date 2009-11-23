using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace MVPCore
{
    public interface IPresenter
    {
		IView View {get; set;}
		IModel Model {get; set;}
		void Initialize();
    }
}
