using HomeManager.HouseholdItems.Actions;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeManager.HouseholdItems
{
    public class Curtain : BaseHouseholdItem
    {
        private string name;
        private bool isOpen;
        public override string GetName { get => name; }


        public Curtain(string name)
        {
            this.name = name;
        }

        public void ToOpen(EquipmentControlPanel controller)
        {
            CheckDeviceOwner(controller);

            isOpen = true;
        }

        public void ToClose(EquipmentControlPanel controller)
        {
            CheckDeviceOwner(controller);

            isOpen = false;
        }

        public override string GetString()
        {
            return $"Name {name}, Is open {isOpen}, Connect {deviceOwner}";
        }

    }
}
