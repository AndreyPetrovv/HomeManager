using System;
using System.Collections.Generic;
using System.Text;
using HomeManager.HouseholdItems;
using HomeManager.Exceptions;

namespace HomeManager.HouseholdItems.Actions
{
    public class ActionMakeCoffe : IAction
    {
        private CoffeeMaker coffeeMaker;

        public ActionMakeCoffe(CoffeeMaker coffeeMaker)
        {
            this.coffeeMaker = coffeeMaker;
        }
        public void DoAction()
        {
            coffeeMaker.MakeCoffee();
        }

        public IHouseholdItem GetHouseholdItem => coffeeMaker;
        

        public string GetString()
        {
            return $"Command Make Coffee for {coffeeMaker.GetName}";
        }
    }
}
