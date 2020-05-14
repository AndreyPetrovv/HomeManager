using HomeManager.HouseholdItems.Actions;
using System;
using System.Collections.Generic;
using System.Text;
using HomeManager.Exceptions;


namespace HomeManager.HouseholdItems
{
    public class Curtain : BaseHouseholdItem
    {
        private bool isOpen;

        public Curtain(string name)
        {
            this.name = name;
        }

        public override List<IAction> SetConnect(EquipmentControlPanel deviceOwner)
        {
            if (this.deviceOwner is null)
            {
                this.deviceOwner = deviceOwner;

                List<IAction> actions = new List<IAction>() {
                    new ActionOpenCurtain(this),
                    new ActionCloseCurtain(this),
                };

                return actions;
            }
            else
            {
                throw new DeviceBusyException();
            }
        }

        public void Open()
        {
            CheckDeviceIsNull();
            isOpen = true;
        }

        public void Close()
        {
            CheckDeviceIsNull();
            isOpen = false;
        }

        public override string GetString()
        {
            return $"Is Active {isActive}; Name {name}, Is open {isOpen}, Connect {deviceOwner}";
        }

    }
}
