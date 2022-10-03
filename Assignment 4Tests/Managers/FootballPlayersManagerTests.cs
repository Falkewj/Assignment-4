using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assignment_4.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_4.Managers.Tests
{
    [TestClass()]
    public class FootballPlayersManagerTests
    {
        [TestMethod()]
        public void GetByIdTest()
        {
            FootballPlayersManager manager = new FootballPlayersManager();
            var list = manager.GetAll();

            var result = manager.GetById(2);

            Assert.AreEqual(result.Name, "Ole");
        }

        [TestMethod()]
        public void GetByIdTest_InvalidId()
        {
            var manager = new FootballPlayersManager();

            var result = manager.GetById(-1);
            
            Assert.AreEqual(result, null);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            var manager = new FootballPlayersManager();
            var ListLength = manager.GetAll().Count;

            var result = manager.Delete(1);

            Assert.AreEqual(ListLength - 1, manager.GetAll().Count);
            Assert.AreEqual(result.Name, "Falke");

        }

        [TestMethod()]
        public void DeleteTest_InvalidId()
        {
            var manager = new FootballPlayersManager();
            var listLength = manager.GetAll().Count;

            var result = manager.Delete(-1);
            
            Assert.AreEqual(manager.GetAll().Count, listLength);
            Assert.IsNull(result);
        }
    }
}