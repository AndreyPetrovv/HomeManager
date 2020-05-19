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
            
            controlPanel.ConnectionEstablishment(new Curtain("test"));

            Assert.AreEqual(controlPanel.GetHouseholdActions.Count, 2);
        }

        [TestMethod]
        public void PushButtonIndexOutOfRangeExceptionTest()
        {
            EquipmentControlPanel controlPanel = new EquipmentControlPanel();
            controlPanel.ConnectionEstablishment(new Curtain("test"));

            Assert.ThrowsException<IndexOutOfRangeException>(() => controlPanel.PushButton(99));
        }

        [TestMethod]
        public void PushButtonItemOfHouseIsTurnOffExceptionTest()
        {
            EquipmentControlPanel controlPanel = new EquipmentControlPanel();
            controlPanel.ConnectionEstablishment(new Curtain("test"));
            controlPanel.GetHouseholdActions[0].GetHouseholdItem.TurnOff();

            Assert.ThrowsException<ItemOfHouseIsTurnOffException>(() => controlPanel.PushButton(0));
        }

    }
}