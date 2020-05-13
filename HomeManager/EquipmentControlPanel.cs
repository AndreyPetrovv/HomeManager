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
        private List<IAction> householdActions;
        public List<IAction> GetHouseholdActions { get => householdActions; }

        public EquipmentControlPanel()
        {
            this.householdActions = new List<IAction>();
        }
        public EquipmentControlPanel(List<IAction> householdActions)
        {
            this.householdActions = householdActions;
        }

        public void PushButton(int actionIndex)
        {
            if (actionIndex < 0 || actionIndex >= householdActions.Count)
            {
                throw new IndexOutOfRangeException();
            }

            IAction action = householdActions[actionIndex];

            if (!action.GetHouseholdItem().ToRespond())
            {
                throw new ItemOfHouseIsTurnOffException();
            }

            action.DoAction();
        }

        public void ConnectionEstablishment(IHouseholdItem householdItem)
        {
            foreach (var item in householdItem.SetConnect(this))
            {
                householdActions.Add(item);
            }
        }

    }
}
