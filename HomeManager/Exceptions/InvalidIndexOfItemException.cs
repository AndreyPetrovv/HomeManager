using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace HomeManager.Exceptions
{
    public class InvalidIndexOfItemException : HouseholdItemException
    {
        public InvalidIndexOfItemException()
            : base(String.Format("Invalid Index Of Item Eception "))
        {
        }

        public InvalidIndexOfItemException(string message)
            : base(String.Format("Invalid Index Of Item Eception ", message))
        {
        }

        public InvalidIndexOfItemException(string message, Exception innerException)
            : base(String.Format("Invalid Index Of Item Eception ", message), innerException)
        {
        }

        protected InvalidIndexOfItemException(SerializationInfo info, StreamingContext context) 
            : base(info, context)
        {
        }
    }
}
