using System;
using System.Collections.Generic;
using System.Text;

namespace HomeManager.Exceptions
{
    class DeviceBusyException : Exception
    {
        public DeviceBusyException()
        : base(String.Format("Device Busy Exception"))
        {

        }
    }
}
