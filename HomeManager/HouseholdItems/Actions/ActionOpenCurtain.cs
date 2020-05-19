using System;
using System.Collections.Generic;
using System.Text;
using HomeManager.Exceptions;

namespace HomeManager.HouseholdItems.Actions
{
    public class ActionOpenCurtain : IAction
    {
        private Curtain curtain;

        public ActionOpenCurtain(Curtain curtain)
        {
            this.curtain = curtain;
        }
        public void DoAction()
        {
            curtain.Open();
        }

        public IHouseholdItem GetHouseholdItem => curtain;
        

        public string GetString()
        {
            return $"Command Open Curtain for {curtain.GetName}";
        }
    }
}
