using System;
using System.Collections.Generic;
using System.Text;
using HomeManager.Exceptions;

namespace HomeManager.HouseholdItems.Actions
{
    public class ActionToCloseCurtain : IAction
    {
        public void DoAction(IHouseholdItem householdItem, EquipmentControlPanel controller)
        {
            if (!(householdItem is Curtain))
            {
                throw new ControllerIsNotEqualDeviceOwnerException();
            }

            ((Curtain)householdItem).ToClose(controller);
        }
    }
}
