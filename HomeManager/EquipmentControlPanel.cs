using System;
using System.Collections.Generic;
using System.Text;
using HomeManager.Exceptions;
using HomeManager.HouseholdItems;
using HomeManager.HouseholdItems.Actions;

namespace HomeManager
{
    public class EquipmentControlPanel
    {
        private List<IHouseholdItem> controlledHomeItems;
        public List<IHouseholdItem> GetControlledHomeItems { get => controlledHomeItems; }

        public EquipmentControlPanel()
        {
            this.controlledHomeItems = new List<IHouseholdItem>();
        }
        public EquipmentControlPanel(List<IHouseholdItem> controlledHomeItems)
        {
            this.controlledHomeItems = controlledHomeItems;
        }

        public void AddHomeItem(IHouseholdItem homeItem)
        {
            homeItem.SetConnect(this);

            controlledHomeItems.Add(homeItem);
        }

        public void PushButton(int itemIndex, IAction action)
        {
            if (itemIndex < 0 || itemIndex >= controlledHomeItems.Count)
            {
                throw new IndexOutOfRangeException();
            }

            IHouseholdItem item = GetControlledHomeItems[itemIndex];

            if (!item.ToRespond())
            {
                throw new ItemOfHouseIsTurnOffException();
            }

            action.DoAction(item, this);
        }

    }
}
