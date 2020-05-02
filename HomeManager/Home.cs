using System;
using System.Collections.Generic;
using System.Text;
using HomeManager.HouseholdItems;
using HomeManager.HouseholdItems.Actions;

namespace HomeManager
{
    public class Home
    {
        private List<IHouseholdItem> allHomeItems;
        public List<IHouseholdItem> GetHomeItems { get => allHomeItems; }

        public Home()
        {
            this.allHomeItems = new List<IHouseholdItem>();
        }
        public Home(List<IHouseholdItem> homeItems)
        {
            this.allHomeItems = homeItems;
        }

        public void AddNewHomeItem(IHouseholdItem item)
        {
            allHomeItems.Add(item);
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
