using System;
using System.Collections.Generic;
using System.Text;

namespace HomeManager.HouseholdItems.Actions
{
    class ActionReplenishCoffee : IAction
    {
        public void DoAction(IHouseholdItem householdItem, EquipmentControlPanel controller)
        {
              ((CoffeeMaker)householdItem).ReplenishCoffee(controller);
        }
    }
}
