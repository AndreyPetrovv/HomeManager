using System;
using System.Collections.Generic;
using System.Text;

namespace HomeManager.Exceptions
{
    class ItemOfHouseIsTurnOffException : Exception
    {
        public ItemOfHouseIsTurnOffException()
        : base(String.Format("Item Of House Is Turn Off Exception"))
        {

        }
    }
}
