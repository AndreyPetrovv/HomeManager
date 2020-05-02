using System;
using System.Collections.Generic;
using System.Text;

namespace HomeManager.Exceptions
{
    class DeviceOwnerIsNullException :Exception
    {
        public DeviceOwnerIsNullException()
        : base(String.Format("Device Owner Is Null Exception"))
        {

        }
    }
}
