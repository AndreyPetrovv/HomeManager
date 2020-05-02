using Microsoft.VisualStudio.TestTools.UnitTesting;
using HomeManager;
using HomeManager.Exceptions;
using HomeManager.HouseholdItems;
using HomeManager.HouseholdItems.Actions;
using System;

namespace UnitTestProject
{
    [TestClass]
    public class EquipmentControlPanelTest
    {
        [TestMethod]
        public void AddControlledItemTest()
        {
            EquipmentControlPanel controlPanel = new EquipmentControlPanel();
            
            controlPanel.AddControlledItem(new Curtain("test"));

            Assert.AreEqual(controlPanel.GetControlledHomeItems.Count, 1);
        }

        [TestMethod]
        public void PushButtonIndexOutOfRangeExceptionTest()
        {
            EquipmentControlPanel controlPanel = new EquipmentControlPanel();
            controlPanel.AddControlledItem(new Curtain("test"));
            ActionMakeCoffe action = new ActionMakeCoffe();

            try
            {
                controlPanel.PushButton(1, action);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, new IndexOutOfRangeException().Message);
            }

        }

        [TestMethod]
        public void PushButtonItemOfHouseIsTurnOffExceptionTest()
        {
            EquipmentControlPanel controlPanel = new EquipmentControlPanel();
            controlPanel.AddControlledItem(new Curtain("test"));
            controlPanel.GetControlledHomeItems[0].TurnOff();
            ActionMakeCoffe action = new ActionMakeCoffe();

            try
            {
                controlPanel.PushButton(0, action);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, new ItemOfHouseIsTurnOffException().Message);
            }
        }

    }
}