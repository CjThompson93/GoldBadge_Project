using Komodo_Badges;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Komodo_Bagdes_Tests
{
    [TestClass]
    public class BadgesTests
    {

        private BadgeRepo _repo;
        private BadgeContent _badge;

        [TestInitialize]
        public void Arrange()
        {
            _repo = new BadgeRepo();
            _badge = new BadgeContent(1234, new List<string> { "A1", "B1", "A2", "A3" });
            _repo.AddBadgeToDictionary(_badge);
        }
        [TestMethod]
        public void AddBadgeToDirectory_ShouldReturnTrue()
        {
            Assert.IsTrue(_repo.GetBadgeList().ContainsKey(1234));
        }
        [TestMethod]
        public void GetBadgeList_ShouldReturnTrue()
        {
            bool contains = _repo.GetBadgeList().ContainsKey(1234);
            Assert.IsTrue(contains);
            int count = _repo.GetBadgeList().Count;
            Assert.AreEqual(1, count);
        }
        //Adding Door
        [TestMethod]
        public void AddingDoorById_ShouldReturnTrue()
        {
            int firstCount = _badge.DoorName.Count;
            _repo.EditDoorById(1234, "A5");
            int secoundCount = _badge.DoorName.Count;
            Assert.IsTrue(_badge.DoorName.Contains("A5"));
            Assert.AreEqual(firstCount + 1, secoundCount);
        }
        //Removing Door
        [TestMethod]
        public void RemovingDoorById_ShouldReturnTrue()
        {
            int firstCount = _badge.DoorName.Count;
            _repo.EditDoorById(1234, "A2");
            int secoundCount = _badge.DoorName.Count;
            Assert.IsTrue(_badge.DoorName.Contains("A2"));
            Assert.AreEqual(firstCount - 1, secoundCount);
        }
        [TestMethod]
        public void GetBadgeInformationById_ShouldReturnTrue()
        {
            var badge = _repo.GetBadgeInfoById(1234);
            Assert.AreEqual(_badge.DoorName, badge);
        }
    }
}
