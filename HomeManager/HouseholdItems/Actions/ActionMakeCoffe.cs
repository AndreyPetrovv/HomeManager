using System;
using System.Collections.Generic;
using System.Text;
using HomeManager.HouseholdItems;

namespace HomeManager.HouseholdItems.Actions
{
    class ActionMakeCoffe : IAction
    {
        public void DoAction(IHouseholdItem householdItem, EquipmentControlPanel controller)
        {
              ((CoffeeMaker)householdItem).MakeCoffee(controller);
        }
    }
}
