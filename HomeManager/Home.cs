using System;
using System.Collections.Generic;
using System.Text;
using HomeManager.HouseholdItems;
using HomeManager.HouseholdItems.Actions;

namespace HomeManager
{
    public class Home
    {
        private EquipmentControlPanel controlPanel;
        private List<IHouseholdItem> allHomeItems;
        public List<IHouseholdItem> GetHomeItems { get => allHomeItems; }

        public Home()
        {
            this.controlPanel = new EquipmentControlPanel();
            this.allHomeItems = new List<IHouseholdItem>();
        }
        public Home(EquipmentControlPanel controlPanel, List<IHouseholdItem> homeItems)
        {
            this.controlPanel = controlPanel;
            this.allHomeItems = homeItems;
        }

        public IHouseholdItem GetItem(int index)
        {
            return allHomeItems[index];
        }

        public void CreateNewHomeItem(IHouseholdItem item)
        {
            allHomeItems.Add(item);
        }

        public void DeleteHomeItem(int index)
        {
            allHomeItems.Add(allHomeItems[index]);
        }

        public void SwitchOffElectricity()
        {
            foreach (var item in allHomeItems)
            {
                item.TurnOff();
            }
        }

        public void SwitchOnElectricity()
        {
            foreach (var item in allHomeItems)
            {
                item.TurnOn();
            }
        }
    }
}
