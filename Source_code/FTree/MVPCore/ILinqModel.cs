using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVPCore
{
    /// <summary>
    /// Skeleton of all LINQ model or data access objects using LINQ technology
    /// in Model layer of MVP pattern.
    /// </summary>
    public interface ILinqModel : IModel
    {
        IQueryable GetAll();
    }

    /// <summary>
    /// Skeleton of all LINQ model or data access objects using LINQ technology
    /// of a specific data type (T) in Model layer of MVP pattern.
    /// </summary>
    public interface ILinqModel<T> : ILinqModel, IModel<T>, IModel
    {
        IQueryable<T> GetAll();
    }
}
