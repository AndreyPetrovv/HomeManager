using HomeManager.HouseholdItems.Actions;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeManager.HouseholdItems
{
    public interface IHouseholdItem
    {
        public string GetName { get; }
        public string GetInfo { get; }
        public bool ToRespond { get; }
        public List<IAction> SetConnect(EquipmentControlPanel deviceOwner);
        public void DropConnect(EquipmentControlPanel controller);
        public void TurnOn();
        public void TurnOff();
        public string GetString();
    }
}
