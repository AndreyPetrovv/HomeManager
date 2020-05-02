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
            controlPanel.AddControlledItem(item);
            item.ReplenishCoffee(controlPanel);
            item.ReplenishdWater(controlPanel);

            item.MakeCoffee(controlPanel);

            Assert.AreEqual(item.GetString(),
                "Name test, Water 90%, Grains Coffee 85%, Connect HomeManager.EquipmentControlPanel");
        }

        [TestMethod]
        public void ReplenishCoffeeTest()
        {
            EquipmentControlPanel controlPanel = new EquipmentControlPanel();
            CoffeeMaker item = new CoffeeMaker("test");
            controlPanel.AddControlledItem(item);

            item.ReplenishCoffee(controlPanel);

            Assert.AreEqual(item.GetString(),
                "Name test, Water 0%, Grains Coffee 100%, Connect HomeManager.EquipmentControlPanel");
        }

        [TestMethod]
        public void ReplenishdWaterTest()
        {
            EquipmentControlPanel controlPanel = new EquipmentControlPanel();
            CoffeeMaker item = new CoffeeMaker("test");
            controlPanel.AddControlledItem(item);

            item.ReplenishdWater(controlPanel);

            Assert.AreEqual(item.GetString(),
                "Name test, Water 100%, Grains Coffee 0%, Connect HomeManager.EquipmentControlPanel");
        }

        [TestMethod]
        public void ActionSetHalfPowerOfLightTest()
        {
            EquipmentControlPanel controlPanel = new EquipmentControlPanel();
            LightBulb item = new LightBulb("test");
            controlPanel.AddControlledItem(item);

            item.SetPowerOfLight(50, controlPanel);

            Assert.AreEqual(item.GetString(),
                "Name test, Power of ight 50%, Connect HomeManager.EquipmentControlPanel");
        }

        [TestMethod]
        public void SetMaxPowerOfLightTest()
        {
            EquipmentControlPanel controlPanel = new EquipmentControlPanel();
            LightBulb item = new LightBulb("test");
            controlPanel.AddControlledItem(item);

            item.SetPowerOfLight(100, controlPanel);

            Assert.AreEqual(item.GetString(),
                "Name test, Power of ight 100%, Connect HomeManager.EquipmentControlPanel");
        }

        [TestMethod]
        public void SetMinPowerOfLightTest()
        {
            EquipmentControlPanel controlPanel = new EquipmentControlPanel();
            LightBulb item = new LightBulb("test");
            controlPanel.AddControlledItem(item);

            item.SetPowerOfLight(10, controlPanel);

            Assert.AreEqual(item.GetString(),
                "Name test, Power of ight 10%, Connect HomeManager.EquipmentControlPanel");
        }

        [TestMethod]
        public void SetZeroPowerOfLightTest()
        {
            EquipmentControlPanel controlPanel = new EquipmentControlPanel();
            LightBulb item = new LightBulb("test");
            controlPanel.AddControlledItem(item);

            item.SetPowerOfLight(0, controlPanel);

            Assert.AreEqual(item.GetString(),
                "Name test, Power of ight 0%, Connect HomeManager.EquipmentControlPanel");
        }

        [TestMethod]
        public void ToCloseCurtainTest()
        {
            EquipmentControlPanel controlPanel = new EquipmentControlPanel();
            Curtain item = new Curtain("test");
            controlPanel.AddControlledItem(item);

            item.ToClose(controlPanel);

            Assert.AreEqual(item.GetString(),
                "Name test, Is open False, Connect HomeManager.EquipmentControlPanel");
        }

        [TestMethod]
        public void ToOpenCurtainTest()
        {
            EquipmentControlPanel controlPanel = new EquipmentControlPanel();
            Curtain item = new Curtain("test");
            controlPanel.AddControlledItem(item);
            item.ToClose(controlPanel);

            item.ToOpen(controlPanel);

            Assert.AreEqual(item.GetString(),
                "Name test, Is open True, Connect HomeManager.EquipmentControlPanel");
        }

        [TestMethod]
        public void ReplenishCoffeeExceptionTest()
        {
            EquipmentControlPanel controlPanel = new EquipmentControlPanel();
            CoffeeMaker item = new CoffeeMaker("test");
            controlPanel.AddControlledItem(item);

            try
            {
                item.MakeCoffee(controlPanel);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, new InvalidIncomingValueException().Message);
            }
        }

        [TestMethod]
        public void SetZeroPowerOfLightExceptionTTest()
        {
            EquipmentControlPanel controlPanel = new EquipmentControlPanel();
            LightBulb item = new LightBulb("test");
            controlPanel.AddControlledItem(item);

            try
            {
                item.SetPowerOfLight(-1, controlPanel);
            }
            catch(Exception ex)
            {
                Assert.AreEqual(ex.Message, new InvalidIncomingValueException().Message);
            }
        }


        [TestMethod]
        public void DeviceOwnerIsNullExceptionTest()
        {
            EquipmentControlPanel controlPanel = new EquipmentControlPanel();
            LightBulb item = new LightBulb("test");

            try
            {
                item.SetPowerOfLight(0, controlPanel);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, new DeviceOwnerIsNullException().Message);
            }
        }

        [TestMethod]
        public void ControllerIsNotEqualDeviceOwnerExceptionTest()
        {
            EquipmentControlPanel controlPanel = new EquipmentControlPanel();
            LightBulb item = new LightBulb("test");
            controlPanel.AddControlledItem(item);

            try
            {
                item.SetPowerOfLight(0, new EquipmentControlPanel());
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, new ControllerIsNotEqualDeviceOwnerException().Message);
            }
        }

        [TestMethod]
        public void DeviceBusyExceptionTest()
        {
            EquipmentControlPanel controlPanel = new EquipmentControlPanel();
            EquipmentControlPanel controlPanel2 = new EquipmentControlPanel();

            LightBulb item = new LightBulb("test");
            controlPanel.AddControlledItem(item);

            try
            {
                controlPanel2.AddControlledItem(item);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, new DeviceBusyException().Message);
            }
        }

        public void DropConnectTest()
        {
            EquipmentControlPanel controlPanel = new EquipmentControlPanel();
            LightBulb item = new LightBulb("test");
            controlPanel.AddControlledItem(item);
            item.DropConnect(controlPanel);

            try
            {
                item.SetPowerOfLight(0, controlPanel);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, new DeviceOwnerIsNullException().Message);
            }
        }

    }
}