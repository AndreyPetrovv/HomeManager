using System;
using System.Collections.Generic;
using System.Text;

namespace HomeManager.HouseholdItems.Actions
{
    class ActionReplenishdWater : IAction
    {
        public void DoAction(IHouseholdItem householdItem, EquipmentControlPanel controller)
        {
              ((CoffeeMaker)householdItem).ReplenishdWater(controller);
        }
    }
}
