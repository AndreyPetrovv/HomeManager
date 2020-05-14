using HomeManager.HouseholdItems.Actions;
using System;
using System.Collections.Generic;
using System.Text;
using HomeManager.Exceptions;


namespace HomeManager.HouseholdItems
{
    public class LightBulb : BaseHouseholdItem
    {
        private int powerOfLight;

        public LightBulb(string name)
        {
            this.name = name;
            this.powerOfLight = 0;
        }

        public override List<IAction> SetConnect(EquipmentControlPanel deviceOwner)
        {
            if (this.deviceOwner is null)
            {
                this.deviceOwner = deviceOwner;

                List<IAction> actions = new List<IAction>() {
                    new ActionUpPowerOfLight(this),
                };

                return actions;
            }
            else
            {
                throw new DeviceBusyException();
            }
        }

        public void SetPowerOfLight(int valuePower)
        {
            CheckDeviceIsNull();
            if (valuePower < -100 || valuePower > 100)
            {
               throw new InvalidIncomingValueException();
            }

            powerOfLight += valuePower;

            if (powerOfLight < 0 )
            {
                powerOfLight = 0;
            }
            else if (powerOfLight > 100)
            {
                powerOfLight = 100;
            }
        }

        public override string GetString()
        {
            return $"Is Active {isActive}; Name {name}, Power of ight {powerOfLight}%, Connect {deviceOwner}";
        }

    }
}
