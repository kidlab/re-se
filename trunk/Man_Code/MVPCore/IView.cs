using System;
using System.Collections.Generic;
using System.Text;

namespace MVPCore
{
    /// <summary>
    /// Skeleton of all view objects in View layer of MVP pattern.
    /// </summary>
    public interface IView
    {
        /// <summary>
        /// Name of this View object.
        /// </summary>
        string ViewName
        {
            get;
        }
    }
}
