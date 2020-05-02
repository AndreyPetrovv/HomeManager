using System;
using System.Collections.Generic;
using System.Text;

namespace HomeManager.HouseholdItems.Actions
{
    public interface IAction
    {
        public void DoAction(IHouseholdItem householdItem, EquipmentControlPanel controller);
    }
}
