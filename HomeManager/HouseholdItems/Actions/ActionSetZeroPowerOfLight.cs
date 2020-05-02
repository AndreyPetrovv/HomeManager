using System;
using System.Collections.Generic;
using System.Text;
using HomeManager.Exceptions;

namespace HomeManager.HouseholdItems.Actions
{
    class ActionSetZeroPowerOfLight : IAction
    {
        public void DoAction(IHouseholdItem householdItem, EquipmentControlPanel controller)
        {
            if (!(householdItem is LightBulb))
            {
                throw new ControllerIsNotEqualDeviceOwnerException();
            }
            ((LightBulb)householdItem).SetPowerOfLight(0, controller);
        }
    }
}
