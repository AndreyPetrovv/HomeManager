using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace HomeManager.Exceptions
{
    public class DeviceOwnerIsNullException : HouseholdItemException
    {
        public DeviceOwnerIsNullException()
            : base(String.Format("Device Owner Is Null Exception "))
        {
        }

        public DeviceOwnerIsNullException(string message)
            : base(String.Format("Device Owner Is Null Exception ", message))
        {
        }

        public DeviceOwnerIsNullException(string message, Exception innerException)
            : base(String.Format("Device Owner Is Null Exception ", message), innerException)
        {
        }

        protected DeviceOwnerIsNullException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
