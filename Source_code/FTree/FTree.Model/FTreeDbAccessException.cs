using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FTree.Common;

namespace FTree.Model
{
    public class FTreeDbAccessException : FTreeBaseException
    {
        public FTreeDbAccessException()
            : base()
        {
        }

        public FTreeDbAccessException(Exception reason)
            : base(reason)
        {
        }

        public FTreeDbAccessException(Exception reason, string message)
            : base(reason, message)
        {
        }
    }
}
