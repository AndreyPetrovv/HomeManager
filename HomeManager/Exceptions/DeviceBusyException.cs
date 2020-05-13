using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace HomeManager.Exceptions
{
    public class DeviceBusyException : HouseholdItemException
    {
        public DeviceBusyException()
            : base(String.Format("Device Busy Exception "))
        {
        }

        public DeviceBusyException(string message)
            : base(String.Format("Device Busy Exception ", message))
        {
        }

        public DeviceBusyException(string message, Exception innerException)
            : base(String.Format("Device Busy Exception ", message), innerException)
        {
        }

        protected DeviceBusyException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
