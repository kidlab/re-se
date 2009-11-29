using System;
using System.Collections;
using System.Collections.Generic;

namespace MVPCore
{
    /// <summary>
    /// Skeleton of all model or data access objects in Model layer of MVP pattern.
    /// </summary>
    public interface IModel
    {
        IList GetAll();
        Object GetOne(int id);
        bool Add(Object obj);
        bool Delete(Object obj);
        bool Save();
    }

    /// <summary>
    /// Skeleton of model (data access objects) of a specific data type (T)
    /// in Model layer of MVP pattern.
    /// </summary>
    public interface IModel<T> : IModel
    {
        IList<T> GetAll();
        T GetOne(int id);
        bool Add(T obj);
        bool Delete(T obj);
    }
}
