using System;
using System.Collections.Generic;
using System.Text;

namespace HomeManager.Exceptions
{
    public class ControllerIsNotEqualDeviceOwnerException: Exception
    {
        public ControllerIsNotEqualDeviceOwnerException()
        : base(String.Format("Controller Is Not Equal Device Owner Exception"))
        {

        }
    }
}
