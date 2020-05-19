using System;
using System.Collections.Generic;
using System.Text;
using HomeManager.Exceptions;

namespace HomeManager.HouseholdItems.Actions
{
    public class ActionUpPowerOfLight : IAction
    {
        private LightBulb lightBulb;

        public ActionUpPowerOfLight(LightBulb lightBulb)
        {
            this.lightBulb = lightBulb;
        }

        public void DoAction()
        {
            lightBulb.SetPowerOfLight(10);
        }

        public IHouseholdItem GetHouseholdItem => lightBulb;
        

        public string GetString()
        {
            return $"Command Up Power Of Light for {lightBulb.GetName}";
        }
    }
}
