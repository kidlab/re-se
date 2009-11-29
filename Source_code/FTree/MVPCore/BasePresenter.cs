using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace MVPCore
{
    public abstract class BasePresenter<TModel, TView> : IDisposable
    {
        #region VARIABLES

        protected TView _view;
        protected TModel _model;

        #endregion

        #region ABSTRACT METHODS

        protected abstract void _disposeComponents();
        
        #endregion
        
        #region IDisposable Members

        public void Dispose()
        {
            _disposeComponents();
        }

        #endregion
    }
}
