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
      
        public void MakeCoffee(EquipmentControlPanel controller)
        {
            CheckDeviceOwner(controller);

            if (percentWater < 10 || percentGrainsCoffee < 15)
            {
                throw new InvalidIncomingValueException();
            }
            percentWater -= 10;
            percentGrainsCoffee -= 15;

        }

        public void ReplenishdWater(EquipmentControlPanel controller)
        {
            CheckDeviceOwner(controller);

            this.percentWater = ReplenishToMaximum(this.percentWater);
        }

        public void ReplenishCoffee(EquipmentControlPanel controller)
        {
            CheckDeviceOwner(controller);

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
