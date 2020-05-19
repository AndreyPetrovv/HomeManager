using System;
using System.Collections.Generic;
using System.Text;
using HomeManager.Exceptions;

namespace HomeManager.HouseholdItems.Actions
{
    public class ActionCloseCurtain : IAction
    {
        private Curtain curtain;

        public ActionCloseCurtain(Curtain curtain)
        {
            this.curtain = curtain;
        }

        public void DoAction()
        {
            curtain.Close();
        }

        public IHouseholdItem GetHouseholdItem => curtain;

        public string GetString()
        {
            return $"Command Close Curtain for {curtain.GetName}";
        }
    }
}
