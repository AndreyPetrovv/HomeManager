using System;
using System.Collections.Generic;
using System.Text;
using HomeManager.Exceptions;

namespace HomeManager.HouseholdItems.Actions
{
    class ActionSetMinPowerOfLight : IAction
    {
        public void DoAction(IHouseholdItem householdItem, EquipmentControlPanel controller)
        {
            if (!(householdItem is LightBulb))
            {
                throw new ControllerIsNotEqualDeviceOwnerException();
            }
              ((LightBulb)householdItem).SetPowerOfLight(10, controller);
        }
    }
}
