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
        void Add(Object obj);
        void Delete(Object obj);
        void Save();
    }

    /// <summary>
    /// Skeleton of model (data access objects) of a specific data type (T)
    /// in Model layer of MVP pattern.
    /// </summary>
    public interface IModel<T>
    {
        IList<T> GetAll();
        T GetOne(int id);
        void Add(T obj);
        void Delete(T obj);
        void Save();
    }
}
