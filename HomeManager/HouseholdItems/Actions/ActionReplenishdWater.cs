using System;
using System.Collections.Generic;
using System.Text;
using HomeManager.Exceptions;

namespace HomeManager.HouseholdItems.Actions
{
    public class ActionReplenishdWater : IAction
    {
        private CoffeeMaker coffeeMaker;

        public ActionReplenishdWater(CoffeeMaker coffeeMaker)
        {
            this.coffeeMaker = coffeeMaker;
        }

        public void DoAction()
        {
            coffeeMaker.ReplenishdWater();
        }

        public IHouseholdItem GetHouseholdItem => coffeeMaker;
        

        public string GetString()
        {
            return $"Command Replenishd Water for {coffeeMaker.GetName}";
        }
    }
}
