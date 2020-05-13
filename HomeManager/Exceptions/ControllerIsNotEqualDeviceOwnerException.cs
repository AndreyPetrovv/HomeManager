using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace HomeManager.Exceptions
{
    public class ControllerIsNotEqualDeviceOwnerException: HouseholdItemException
    {
        public ControllerIsNotEqualDeviceOwnerException()
            : base(String.Format("Controller Is Not Equal Device Owner Exception "))
        {
        }

        public ControllerIsNotEqualDeviceOwnerException(string message)
            : base(String.Format("Controller Is Not Equal Device Owner Exception ", message))
        {
        }

        public ControllerIsNotEqualDeviceOwnerException(string message, Exception innerException)
            : base(String.Format("Controller Is Not Equal Device Owner Exception ", message), innerException)
        {
        }

        protected ControllerIsNotEqualDeviceOwnerException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
