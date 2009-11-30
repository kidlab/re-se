using System;

namespace FTree.Common
{
    /// <summary>
    /// Can be used as the base class for all classes in the project; it is the root of the type hierarchy.
    /// But there is no force to derive from this class.
    /// </summary>
    public class BaseObject : Object
    {
        /// <summary>
        /// Creates a shallow copy of the current Object (the copied object will not a reference to this object).
        /// </summary>
        /// <returns>A shallow copy of this object.</returns>
        public virtual object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
