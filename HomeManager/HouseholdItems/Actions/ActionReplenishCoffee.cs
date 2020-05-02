using System;
using System.Collections.Generic;
using System.Text;
using HomeManager.Exceptions;

namespace HomeManager.HouseholdItems.Actions
{
    class ActionReplenishCoffee : IAction
    {
        public void DoAction(IHouseholdItem householdItem, EquipmentControlPanel controller)
        {
            if (!(householdItem is CoffeeMaker))
            {
                throw new ControllerIsNotEqualDeviceOwnerException();
            }
            ((CoffeeMaker)householdItem).ReplenishCoffee(controller);
        }
    }
}
