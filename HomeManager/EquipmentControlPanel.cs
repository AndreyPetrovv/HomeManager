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


        public IHouseholdItem GetItem(int index)
        {
            if (index < 0 || index >= controlledHomeItems.Count)
            {
                throw new InvalidIndexOfItemException();
            }

            return controlledHomeItems[index];
        }
        public void AddHomeItem(IHouseholdItem homeItem)
        {
            homeItem.SetConnect(this);

            controlledHomeItems.Add(homeItem);

        }
        public void RemoveHomeItem(int index)
        {
            if (index >= 0 && index < controlledHomeItems.Count)
            {
                controlledHomeItems[index].DropConnect(this);
                controlledHomeItems.Remove(controlledHomeItems[index]);
            }
        }
        public void RemoveHomeItem(IHouseholdItem homeItem)
        {
            foreach (var item in controlledHomeItems)
            {
                if (item.Equals(homeItem))
                {
                    item.DropConnect(this);
                    controlledHomeItems.Remove(item);
                }
            }
        }

        public void PushButton(int itemIndex, IAction action)
        {
            IHouseholdItem item = GetItem(itemIndex);

            if (!item.ToRespond())
            {
               throw new ItemOfHouseIsTurnOffException();
            }

            action.DoAction(item, this);

        }

    }
}
