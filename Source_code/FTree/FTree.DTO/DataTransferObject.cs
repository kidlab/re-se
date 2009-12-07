using System;
using System.Collections.Generic;
using System.Text;

namespace FTree.DTO
{
    /// <summary>
    /// Base class of all data transfer objects.
    /// </summary>
    public class DataTransferObject : FTree.Common.BaseObject
    {
        /// <summary>
        /// Identification number of this object.
        /// </summary>
        public int ID {get; set;}
    }
}