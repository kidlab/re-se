using System;
using System.Collections;
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
        IEnumerable GetEnumerator();

        /// <summary>
        /// Submit all changes to DB.
        /// </summary>
        void Save();

        /// <summary>
        /// Gets or sets the value determining that the model will automatically submit all changes to DB or not.
        /// </summary>
        bool AutoSubmitChanges { get; set; }
    }

    /// <summary>
    /// Skeleton of all LINQ model or data access objects using LINQ technology
    /// of a specific data type (T) in Model layer of MVP pattern.
    /// </summary>
    public interface ILinqModel<T> : IModel<T>
    {
        IEnumerable<T> GetEnumerator();

        /// <summary>
        /// Submit all changes to DB.
        /// </summary>
        void Save();

        /// <summary>
        /// Gets or sets the value determining that the model will automatically submit all changes to DB or not.
        /// </summary>
        bool AutoSubmitChanges { get; set; }
    }
}
