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

        public void SetPowerOfLight(int valuePower, EquipmentControlPanel controller)
        {
            CheckDeviceOwner(controller);

            if (valuePower < 0 || valuePower > 100)
            {
               throw new InvalidIncomingValueException();
            }

            powerOfLight = valuePower;
        }

        public override string GetString()
        {
            return $"Name {name}, Power of ight {powerOfLight}%, Connect {deviceOwner}";
        }

    }
}
