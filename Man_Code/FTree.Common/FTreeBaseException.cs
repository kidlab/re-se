using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FTree.Common
{
    public class FTreeBaseException : Exception
    {
        protected Exception _reason;
        protected string _message;

        public FTreeBaseException()
        {            
        }

        public FTreeBaseException(Exception reason)
        {
            _reason = reason;
        }

        public FTreeBaseException(Exception reason, string message)
        {
            _reason = reason;
            _message = message;
        }

        public override string Message
        {
            get
            {
                if (!String.IsNullOrEmpty(_message))
                    return _message;
                return base.Message;
            }
        }
    }
}
