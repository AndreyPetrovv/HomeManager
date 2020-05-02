using System;
using System.Collections.Generic;
using System.Text;

namespace HomeManager.HouseholdItems.Actions
{
    class ActionSetMaxPowerOfLight : IAction
    {
        public void DoAction(IHouseholdItem householdItem, EquipmentControlPanel controller)
        {
              ((LightBulb)householdItem).SetPowerOfLight(100 ,controller);
        }
    }
}
