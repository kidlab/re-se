using System;
using System.Collections.Generic;
using System.Text;

namespace FTree.DTO
{
    /// <summary>
    /// Base class of all data transfer objects.
    /// </summary>
    public class DataTransferObject
    {
        /// <summary>
        /// Identification number of this object.
        /// </summary>
		public int ID {get; set;}

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