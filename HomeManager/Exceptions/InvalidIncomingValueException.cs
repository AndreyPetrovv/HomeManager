using System;
using System.Collections.Generic;
using System.Text;

namespace HomeManager.Exceptions
{
    class InvalidIncomingValueException : Exception
    {
        public InvalidIncomingValueException()
        : base(String.Format("Invalid Incoming Value Exception"))
        {

        }
    }
}
