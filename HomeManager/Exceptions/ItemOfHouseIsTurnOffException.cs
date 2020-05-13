using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace HomeManager.Exceptions
{
    public class ItemOfHouseIsTurnOffException : HouseholdItemException
    {
        public ItemOfHouseIsTurnOffException()
            : base(String.Format("Item Of House Is Turn Off Exception "))
        {
        }

        public ItemOfHouseIsTurnOffException(string message) 
            : base(String.Format("Item Of House Is Turn Off Exception ", message))
        {
        }

        public ItemOfHouseIsTurnOffException(string message, Exception innerException) 
            : base(String.Format("Item Of House Is Turn Off Exception ", message), innerException)
        {
        }

        protected ItemOfHouseIsTurnOffException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
