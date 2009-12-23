using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FTree.Common;

namespace FTree.Presenter
{
    public class FTreePresenterException : FTreeBaseException
    {
        public FTreePresenterException()
            : base()
        {
        }

        public FTreePresenterException(string message)
            : base()
        {
            _message = message;
        }

        public FTreePresenterException(Exception reason)
            : base(reason)
        {
        }

        public FTreePresenterException(Exception reason, string message)
            : base(reason, message)
        {
        }
    }
}
