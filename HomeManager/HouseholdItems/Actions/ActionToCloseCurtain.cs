using System;
using System.Collections.Generic;
using System.Text;

namespace HomeManager.HouseholdItems.Actions
{
    class ActionToCloseCurtain: IAction
    {
        public void DoAction(IHouseholdItem householdItem, EquipmentControlPanel controller)
        {
              ((Curtain)householdItem).ToClose(controller);
        }
    }
}
