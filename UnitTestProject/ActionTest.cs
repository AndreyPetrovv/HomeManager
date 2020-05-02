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
            EquipmentControlPanel controlPanel = new EquipmentControlPanel();
            controlPanel.AddControlledItem(new CoffeeMaker("test"));
            ActionReplenishdWater actionw = new ActionReplenishdWater();
            controlPanel.PushButton(0, actionw);
            ActionReplenishCoffee actionc = new ActionReplenishCoffee();
            controlPanel.PushButton(0, actionc);
            ActionMakeCoffe action = new ActionMakeCoffe();

            controlPanel.PushButton(0, action);

            Assert.AreEqual(controlPanel.GetControlledHomeItems[0].GetString(),
                "Name test, Water 90%, Grains Coffee 85%, Connect HomeManager.EquipmentControlPanel");
        }

        [TestMethod]
        public void ActionReplenishCoffeeTest()
        {
            EquipmentControlPanel controlPanel = new EquipmentControlPanel();
            controlPanel.AddControlledItem(new CoffeeMaker("test"));
            ActionReplenishCoffee action = new ActionReplenishCoffee();

            controlPanel.PushButton(0, action);

            Assert.AreEqual(controlPanel.GetControlledHomeItems[0].GetString(),
                "Name test, Water 0%, Grains Coffee 100%, Connect HomeManager.EquipmentControlPanel");
        }

        [TestMethod]
        public void ActionReplenishdWaterTest()
        {
            EquipmentControlPanel controlPanel = new EquipmentControlPanel();
            controlPanel.AddControlledItem(new CoffeeMaker("test"));
            ActionReplenishdWater action = new ActionReplenishdWater();

            controlPanel.PushButton(0, action);

            Assert.AreEqual(controlPanel.GetControlledHomeItems[0].GetString(),
                "Name test, Water 100%, Grains Coffee 0%, Connect HomeManager.EquipmentControlPanel");
        }

        [TestMethod]
        public void ActionSetHalfPowerOfLightTest()
        {
            EquipmentControlPanel controlPanel = new EquipmentControlPanel();
            controlPanel.AddControlledItem(new LightBulb("test"));
            ActionSetHalfPowerOfLight action = new ActionSetHalfPowerOfLight();

            controlPanel.PushButton(0, action);

            Assert.AreEqual(controlPanel.GetControlledHomeItems[0].GetString(),
                "Name test, Power of ight 50%, Connect HomeManager.EquipmentControlPanel");
        }

        [TestMethod]
        public void ActionSetMaxPowerOfLightTest()
        {
            EquipmentControlPanel controlPanel = new EquipmentControlPanel();
            controlPanel.AddControlledItem(new LightBulb("test"));
            ActionSetMaxPowerOfLight action = new ActionSetMaxPowerOfLight();

            controlPanel.PushButton(0, action);

            Assert.AreEqual(controlPanel.GetControlledHomeItems[0].GetString(),
                "Name test, Power of ight 100%, Connect HomeManager.EquipmentControlPanel");
        }

        [TestMethod]
        public void ActionSetMinPowerOfLightTest()
        {
            EquipmentControlPanel controlPanel = new EquipmentControlPanel();
            controlPanel.AddControlledItem(new LightBulb("test"));
            ActionSetMinPowerOfLight action = new ActionSetMinPowerOfLight();

            controlPanel.PushButton(0, action);

            Assert.AreEqual(controlPanel.GetControlledHomeItems[0].GetString(),
                "Name test, Power of ight 10%, Connect HomeManager.EquipmentControlPanel");
        }

        [TestMethod]
        public void ActionSetZeroPowerOfLightTest()
        {
            EquipmentControlPanel controlPanel = new EquipmentControlPanel();
            controlPanel.AddControlledItem(new LightBulb("test"));
            ActionSetMaxPowerOfLight actionm = new ActionSetMaxPowerOfLight();
            controlPanel.PushButton(0, actionm);
            ActionSetZeroPowerOfLight action = new ActionSetZeroPowerOfLight();

            controlPanel.PushButton(0, action);

            Assert.AreEqual(controlPanel.GetControlledHomeItems[0].GetString(),
                "Name test, Power of ight 0%, Connect HomeManager.EquipmentControlPanel");
        }

        [TestMethod]
        public void ActionToCloseCurtainTest()
        {
            EquipmentControlPanel controlPanel = new EquipmentControlPanel();
            controlPanel.AddControlledItem(new Curtain("test"));
            ActionToOpenCurtain actiono = new ActionToOpenCurtain();
            controlPanel.PushButton(0, actiono);
            ActionToCloseCurtain action = new ActionToCloseCurtain();

            controlPanel.PushButton(0, action);

            Assert.AreEqual(controlPanel.GetControlledHomeItems[0].GetString(),
                "Name test, Is open False, Connect HomeManager.EquipmentControlPanel");
        }

        [TestMethod]
        public void ActionToOpenCurtainTest()
        {
            EquipmentControlPanel controlPanel = new EquipmentControlPanel();
            controlPanel.AddControlledItem(new Curtain("test"));
            ActionToOpenCurtain action = new ActionToOpenCurtain();

            controlPanel.PushButton(0, action);

            Assert.AreEqual(controlPanel.GetControlledHomeItems[0].GetString(),
                "Name test, Is open True, Connect HomeManager.EquipmentControlPanel");
        }


        [TestMethod]
        public void ActionMakeCoffeExceptionTest()
        {
            EquipmentControlPanel controlPanel = new EquipmentControlPanel();
            controlPanel.AddControlledItem(new Curtain("test"));
            ActionMakeCoffe action = new ActionMakeCoffe();

            try
            {
                controlPanel.PushButton(0, action);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, new ControllerIsNotEqualDeviceOwnerException().Message);
            }
        }

        [TestMethod]
        public void ActionReplenishCoffeeExceptionTest()
        {
            EquipmentControlPanel controlPanel = new EquipmentControlPanel();
            controlPanel.AddControlledItem(new Curtain("test"));
            ActionReplenishCoffee action = new ActionReplenishCoffee();

            try
            {
                controlPanel.PushButton(0, action);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, new ControllerIsNotEqualDeviceOwnerException().Message);
            }
        }

        [TestMethod]
        public void ActionReplenishdWaterExceptionTest()
        {
            EquipmentControlPanel controlPanel = new EquipmentControlPanel();
            controlPanel.AddControlledItem(new Curtain("test"));
            ActionReplenishdWater action = new ActionReplenishdWater();

            try
            {
                controlPanel.PushButton(0, action);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, new ControllerIsNotEqualDeviceOwnerException().Message);
            }
        }

        [TestMethod]
        public void ActionSetHalfPowerOfLightExceptionTest()
        {
            EquipmentControlPanel controlPanel = new EquipmentControlPanel();
            controlPanel.AddControlledItem(new Curtain("test"));
            ActionSetHalfPowerOfLight action = new ActionSetHalfPowerOfLight();

            try
            {
                controlPanel.PushButton(0, action);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, new ControllerIsNotEqualDeviceOwnerException().Message);
            }
        }

        [TestMethod]
        public void ActionSetMaxPowerOfLightExceptionTest()
        {
            EquipmentControlPanel controlPanel = new EquipmentControlPanel();
            controlPanel.AddControlledItem(new Curtain("test"));
            ActionSetMaxPowerOfLight action = new ActionSetMaxPowerOfLight();

            try
            {
                controlPanel.PushButton(0, action);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, new ControllerIsNotEqualDeviceOwnerException().Message);
            }
        }

        [TestMethod]
        public void ActionSetMinPowerOfLightExceptionTest()
        {
            EquipmentControlPanel controlPanel = new EquipmentControlPanel();
            controlPanel.AddControlledItem(new Curtain("test"));
            ActionSetMinPowerOfLight action = new ActionSetMinPowerOfLight();

            try
            {
                controlPanel.PushButton(0, action);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, new ControllerIsNotEqualDeviceOwnerException().Message);
            }
        }

        [TestMethod]
        public void ActionSetZeroPowerOfLightExceptionTest()
        {
            EquipmentControlPanel controlPanel = new EquipmentControlPanel();
            controlPanel.AddControlledItem(new Curtain("test"));
            ActionSetZeroPowerOfLight action = new ActionSetZeroPowerOfLight();

            try
            {
                controlPanel.PushButton(0, action);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, new ControllerIsNotEqualDeviceOwnerException().Message);
            }
        }

        [TestMethod]
        public void ActionToCloseCurtainExceptionTest()
        {
            EquipmentControlPanel controlPanel = new EquipmentControlPanel();
            controlPanel.AddControlledItem(new LightBulb("test"));
            ActionToCloseCurtain action = new ActionToCloseCurtain();

            try
            {
                controlPanel.PushButton(0, action);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, new ControllerIsNotEqualDeviceOwnerException().Message);
            }
        }

        [TestMethod]
        public void ActionToOpenCurtainExceptionTest()
        {
            EquipmentControlPanel controlPanel = new EquipmentControlPanel();
            controlPanel.AddControlledItem(new LightBulb("test"));
            ActionToOpenCurtain action = new ActionToOpenCurtain();

            try
            {
                controlPanel.PushButton(0, action);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, new ControllerIsNotEqualDeviceOwnerException().Message);
            }
        }

    }
}
