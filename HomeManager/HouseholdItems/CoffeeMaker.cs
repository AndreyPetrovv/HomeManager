using HomeManager.HouseholdItems.Actions;
using System;
using System.Collections.Generic;
using System.Text;
using HomeManager.Exceptions;


namespace HomeManager.HouseholdItems
{
    public class CoffeeMaker: BaseHouseholdItem
    {
        
        private int percentWater;
        private int percentGrainsCoffee;

        public CoffeeMaker(string name)
        {
            this.name = name;
            this.percentWater = 0;
            this.percentGrainsCoffee = 0;
        }

        public override List<IAction> SetConnect(EquipmentControlPanel deviceOwner)
        {
            if (this.deviceOwner is null)
            {
                this.deviceOwner = deviceOwner;

                List<IAction> actions = new List<IAction>() {
                    new ActionMakeCoffe(this),
                    new ActionReplenishCoffee(this),
                    new ActionReplenishdWater(this), 
                };

                return actions;
            }
            else
            {
                throw new DeviceBusyException();
            }
        }

        public void MakeCoffee()
        {
            CheckDeviceIsNull();
            if (percentWater < 10 || percentGrainsCoffee < 15)
            {
                throw new InvalidIncomingValueException();
            }
            percentWater -= 10;
            percentGrainsCoffee -= 15;
        }

        public void ReplenishdWater()
        {
            CheckDeviceIsNull();
            this.percentWater = ReplenishToMaximum(this.percentWater);
        }

        public void ReplenishCoffee()
        {
            CheckDeviceIsNull();
            this.percentGrainsCoffee = ReplenishToMaximum(this.percentGrainsCoffee);
        }

        private int ReplenishToMaximum(int currPercent)
        {
            return 100;
        }

        public override string GetString()
        {
            return $"Name {name}, Water {percentWater}%, Grains Coffee {percentGrainsCoffee}%, Connect {deviceOwner}"; 
        }

    }
}
