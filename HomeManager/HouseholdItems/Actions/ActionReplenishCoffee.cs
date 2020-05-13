using System;
using System.Collections.Generic;
using System.Text;
using HomeManager.Exceptions;

namespace HomeManager.HouseholdItems.Actions
{
    public class ActionReplenishCoffee : IAction
    {
        private CoffeeMaker coffeeMaker;

        public ActionReplenishCoffee(CoffeeMaker coffeeMaker)
        {
            this.coffeeMaker = coffeeMaker;
        }
        public void DoAction()
        {
            coffeeMaker.ReplenishCoffee();
        }

        public IHouseholdItem GetHouseholdItem()
        {
            return coffeeMaker;
        }

        public string GetString()
        {
            return $"Command Replenishd Coffee for {coffeeMaker.GetName}";
        }
    }
}
