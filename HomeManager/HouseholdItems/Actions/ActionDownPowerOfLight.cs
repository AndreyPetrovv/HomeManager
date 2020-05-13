using System;
using System.Collections.Generic;
using System.Text;
using HomeManager.Exceptions;

namespace HomeManager.HouseholdItems.Actions
{
    public class ActionDownPowerOfLight : IAction
    {
        private LightBulb lightBulb;

        public ActionDownPowerOfLight(LightBulb lightBulb)
        {
            this.lightBulb = lightBulb;
        }

        public void DoAction()
        {
            lightBulb.SetPowerOfLight(-10);
        }

        public IHouseholdItem GetHouseholdItem()
        {
            return lightBulb;
        }

        public string GetString()
        {
            return $"Command Down Power Of Light for {lightBulb.GetName}";
        }
    }
}
