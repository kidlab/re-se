using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace MVPCore
{
    /// <summary>
    /// Skeleton of all presenter objects in Presenter layer of MVP pattern.
    /// </summary>
    public interface IPresenter
    {
        IView View { get; set; }
        IModel Model { get; set; }
        void Initialize();
    }

    /// <summary>
    /// Skeleton of presenter of a specific data type (T) 
    /// in Presenter layer of MVP pattern.
    /// </summary>
    public interface IPresenter<T> : IPresenter
    {
        IModel<T> Model { get; set; }
    }
}
