using Microsoft.VisualStudio.TestTools.UnitTesting;
using HomeManager;
using HomeManager.Exceptions;
using HomeManager.HouseholdItems;
using HomeManager.HouseholdItems.Actions;
using System;

namespace UnitTestProject
{
    [TestClass]
    public class ActionTest
    {
        [TestMethod]
        public void ActionMakeCoffeTest()
        {

            CoffeeMaker coffeeMaker = new CoffeeMaker("test");
            EquipmentControlPanel controlPanel = new EquipmentControlPanel();
            controlPanel.ConnectionEstablishment(coffeeMaker);
            ActionMakeCoffe action = new ActionMakeCoffe(coffeeMaker);
            ActionReplenishCoffee actionReplenish = new ActionReplenishCoffee(coffeeMaker);
            ActionReplenishdWater replenishdWater = new ActionReplenishdWater(coffeeMaker);
            actionReplenish.DoAction();
            replenishdWater.DoAction();
            

            action.DoAction();

            Assert.AreEqual(action.GetHouseholdItem().GetString(),
                "Name test, Water 90%, Grains Coffee 85%, Connect HomeManager.EquipmentControlPanel");
        }

        [TestMethod]
        public void ActionReplenishCoffeeTest()
        {
            CoffeeMaker coffeeMaker = new CoffeeMaker("test");
            ActionReplenishCoffee action = new ActionReplenishCoffee(coffeeMaker);
            EquipmentControlPanel controlPanel = new EquipmentControlPanel();
            controlPanel.ConnectionEstablishment(coffeeMaker);

            action.DoAction();

            Assert.AreEqual(action.GetHouseholdItem().GetString(),
                "Name test, Water 0%, Grains Coffee 100%, Connect HomeManager.EquipmentControlPanel");
        }

        [TestMethod]
        public void ActionReplenishdWaterTest()
        {
            CoffeeMaker coffeeMaker = new CoffeeMaker("test");
            ActionReplenishdWater action = new ActionReplenishdWater(coffeeMaker);
            EquipmentControlPanel controlPanel = new EquipmentControlPanel();
            controlPanel.ConnectionEstablishment(coffeeMaker);

            action.DoAction();

            Assert.AreEqual(action.GetHouseholdItem().GetString(),
                "Name test, Water 100%, Grains Coffee 0%, Connect HomeManager.EquipmentControlPanel");
        }

        [TestMethod]
        public void ActionUpPowerOfLightTest()
        {
            LightBulb lightBulb = new LightBulb("test");
            ActionUpPowerOfLight action = new ActionUpPowerOfLight(lightBulb);
            EquipmentControlPanel controlPanel = new EquipmentControlPanel();
            controlPanel.ConnectionEstablishment(lightBulb);

            action.DoAction();

            Assert.AreEqual(action.GetHouseholdItem().GetString(),
                "Name test, Power of ight 10%, Connect HomeManager.EquipmentControlPanel");
        }

        [TestMethod]
        public void ActionDownPowerOfLightTest()
        {
            LightBulb lightBulb = new LightBulb("test");
            EquipmentControlPanel controlPanel = new EquipmentControlPanel();
            controlPanel.ConnectionEstablishment(lightBulb);
            ActionUpPowerOfLight actionU = new ActionUpPowerOfLight(lightBulb);
            actionU.DoAction();
            actionU.DoAction();
            ActionDownPowerOfLight actionD = new ActionDownPowerOfLight(lightBulb);

            actionD.DoAction();

            Assert.AreEqual(actionD.GetHouseholdItem().GetString(),
                "Name test, Power of ight 10%, Connect HomeManager.EquipmentControlPanel");
        }

        [TestMethod]
        public void ActionToCloseCurtainTest()
        {
            Curtain curtain = new Curtain("test");
            EquipmentControlPanel controlPanel = new EquipmentControlPanel();
            controlPanel.ConnectionEstablishment(curtain);
            ActionOpenCurtain actionO = new ActionOpenCurtain(curtain);
            actionO.DoAction();
            ActionCloseCurtain action = new ActionCloseCurtain(curtain);
            

            action.DoAction();

            Assert.AreEqual(action.GetHouseholdItem().GetString(),
                "Name test, Is open False, Connect HomeManager.EquipmentControlPanel");
        }

        [TestMethod]
        public void ActionToOpenCurtainTest()
        {
            Curtain curtain = new Curtain("test");
            EquipmentControlPanel controlPanel = new EquipmentControlPanel();
            controlPanel.ConnectionEstablishment(curtain);
            ActionOpenCurtain action = new ActionOpenCurtain(curtain);

            action.DoAction();

            Assert.AreEqual(action.GetHouseholdItem().GetString(),
                "Name test, Is open True, Connect HomeManager.EquipmentControlPanel");
        }

    }
}
