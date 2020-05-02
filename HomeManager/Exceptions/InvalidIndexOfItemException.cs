using System;
using System.Collections.Generic;
using System.Text;

namespace HomeManager.Exceptions
{
    public class InvalidIndexOfItemException : Exception
    {
        public InvalidIndexOfItemException()
        : base(String.Format("Invalid Index Of Item Eception"))
        {

        }
    }
}
