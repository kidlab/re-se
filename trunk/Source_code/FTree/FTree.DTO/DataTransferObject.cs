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
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the object that contains data about this item.
        /// </summary>
        public object Tag { get; set; }

        /// <summary>
        /// The currrent status of this object (ex: just created, copied, updated or deleted).
        /// </summary>
        public DataState State { get; set; }

        public DataTransferObject()
        {
            State = DataState.New;
        }
    }
}