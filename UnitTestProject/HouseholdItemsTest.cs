using Microsoft.VisualStudio.TestTools.UnitTesting;
using HomeManager;
using HomeManager.Exceptions;
using HomeManager.HouseholdItems;
using HomeManager.HouseholdItems.Actions;
using System;


namespace UnitTestProject
{
    [TestClass]
    public class HouseholdItemsTest
    {
        [TestMethod]
        public void MakeCoffeTest()
        {
            EquipmentControlPanel controlPanel = new EquipmentControlPanel();
            CoffeeMaker item = new CoffeeMaker("test");
            controlPanel.ConnectionEstablishment(item);
            item.ReplenishCoffee();
            item.ReplenishdWater();

            item.MakeCoffee();

            Assert.AreEqual(item.GetString(),
                "Is Active True; Name test, Water 90%, Grains Coffee 85%, Connect HomeManager.EquipmentControlPanel");
        }

        [TestMethod]
        public void ReplenishCoffeeTest()
        {
            EquipmentControlPanel controlPanel = new EquipmentControlPanel();
            CoffeeMaker item = new CoffeeMaker("test");
            controlPanel.ConnectionEstablishment(item);

            item.ReplenishCoffee();

            Assert.AreEqual(item.GetString(),
                "Is Active True; Name test, Water 0%, Grains Coffee 100%, Connect HomeManager.EquipmentControlPanel");
        }

        [TestMethod]
        public void ReplenishdWaterTest()
        {
            EquipmentControlPanel controlPanel = new EquipmentControlPanel();
            CoffeeMaker item = new CoffeeMaker("test");
            controlPanel.ConnectionEstablishment(item);

            item.ReplenishdWater();

            Assert.AreEqual(item.GetString(),
                "Is Active True; Name test, Water 100%, Grains Coffee 0%, Connect HomeManager.EquipmentControlPanel");
        }

        [TestMethod]
        public void SetPowerOfLightTest()
        {
            EquipmentControlPanel controlPanel = new EquipmentControlPanel();
            LightBulb item = new LightBulb("test");
            controlPanel.ConnectionEstablishment(item);

            item.SetPowerOfLight(50);

            Assert.AreEqual(item.GetString(),
                "Is Active True; Name test, Power of ight 50%, Connect HomeManager.EquipmentControlPanel");
        }

        [TestMethod]
        public void ToCloseCurtainTest()
        {
            EquipmentControlPanel controlPanel = new EquipmentControlPanel();
            Curtain item = new Curtain("test");
            controlPanel.ConnectionEstablishment(item);

            item.Close();

            Assert.AreEqual(item.GetString(),
                "Is Active True; Name test, Is open False, Connect HomeManager.EquipmentControlPanel");
        }

        [TestMethod]
        public void ToOpenCurtainTest()
        {
            EquipmentControlPanel controlPanel = new EquipmentControlPanel();
            Curtain item = new Curtain("test");
            controlPanel.ConnectionEstablishment(item);
            item.Close();

            item.Open();

            Assert.AreEqual(item.GetString(),
                "Is Active True; Name test, Is open True, Connect HomeManager.EquipmentControlPanel");
        }

        [TestMethod]
        public void ReplenishCoffeeExceptionTest()
        {
            EquipmentControlPanel controlPanel = new EquipmentControlPanel();
            CoffeeMaker item = new CoffeeMaker("test");
            controlPanel.ConnectionEstablishment(item);

            Assert.ThrowsException<InvalidIncomingValueException>(() => item.MakeCoffee());
        }

        [TestMethod]
        public void SetZeroPowerOfLightExceptionTTest()
        {
            EquipmentControlPanel controlPanel = new EquipmentControlPanel();
            LightBulb item = new LightBulb("test");
            controlPanel.ConnectionEstablishment(item);

            Assert.ThrowsException<InvalidIncomingValueException>(() => item.SetPowerOfLight(-1001));
        }


        [TestMethod]
        public void DeviceOwnerIsNullExceptionTest()
        {
            EquipmentControlPanel controlPanel = new EquipmentControlPanel();
            LightBulb item = new LightBulb("test");

            Assert.ThrowsException<DeviceOwnerIsNullException>(() => item.SetPowerOfLight(0));
        }

        public void DropConnectTest()
        {
            EquipmentControlPanel controlPanel = new EquipmentControlPanel();
            LightBulb item = new LightBulb("test");
            controlPanel.ConnectionEstablishment(item);
            item.DropConnect(controlPanel);

            Assert.ThrowsException<DeviceOwnerIsNullException>(() => item.SetPowerOfLight(0));
        }

    }
}