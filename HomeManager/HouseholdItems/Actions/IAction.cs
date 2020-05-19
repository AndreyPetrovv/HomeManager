using System;
using System.Collections.Generic;
using System.Text;

namespace HomeManager.HouseholdItems.Actions
{
    public interface IAction
    {
        public IHouseholdItem GetHouseholdItem { get; }

        public void DoAction();
        public string GetString();
    }
}
