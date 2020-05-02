using Microsoft.VisualStudio.TestTools.UnitTesting;
using HomeManager;
using HomeManager.HouseholdItems;

namespace UnitTestProject
{
    [TestClass]
    public class Actions
    {

        [TestMethod]
        public void TestAddNewHomeItem()
        {
            Home home = new Home();

            home.AddNewHomeItem(new Curtain("test"));

            Assert.AreEqual(home.GetHomeItems.Count, 1);
        }

        [TestMethod]
        public void TestSwitchOffElectricity()
        {
            Home home = new Home();
            home.AddNewHomeItem(new Curtain("test"));

            home.SwitchOffElectricity();

            Assert.AreEqual(home.GetHomeItems[0].ToRespond(), false);
        }

        [TestMethod]
        public void TestSwitchOnElectricity()
        {
            Home home = new Home();
            home.AddNewHomeItem(new Curtain("test"));
            home.SwitchOffElectricity();

            home.SwitchOnElectricity();

            Assert.AreEqual(home.GetHomeItems[0].ToRespond(), true);
        }
    }
}
