using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace HomeManager.Exceptions
{
    public class HouseholdItemException : Exception
    {
        public HouseholdItemException()
        {
        }

        public HouseholdItemException(string message)
            : base(message)
        {
        }

        public HouseholdItemException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected HouseholdItemException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
