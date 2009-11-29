using System;
using System.Collections.Generic;
using System.Text;

namespace FTree.Common
{
    public interface IValidatable
    {
        /// <summary>
        /// Validates user's input data.
        /// </summary>
        /// <returns></returns>
        bool Validate();
    }
}
