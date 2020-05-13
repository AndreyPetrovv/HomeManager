using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace HomeManager.Exceptions
{
    public class InvalidIncomingValueException : HouseholdItemException
    {
        public InvalidIncomingValueException()
            : base(String.Format("Invalid Incoming Value Exception "))
        {
        }

        public InvalidIncomingValueException(string message)
            : base(String.Format("Invalid Incoming Value Exception ", message))
        {
        }

        public InvalidIncomingValueException(string message, Exception innerException)
            : base(String.Format("Invalid Incoming Value Exception ", message), innerException)
        {
        }

        protected InvalidIncomingValueException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
