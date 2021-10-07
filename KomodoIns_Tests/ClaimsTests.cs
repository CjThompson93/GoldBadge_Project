using KomodoIns;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace KomodoIns_Tests
{
    [TestClass]
    public class ClaimsTests
    {
        private ClaimsRepo _repo;
        private ClaimsContent _claim;

        [TestInitialize]
        public void Arrange()
        {
            _repo = new ClaimsRepo();
            _claim = new ClaimsContent(1, ClaimType.Car, "Accident on 465.", 400.00m, new DateTime(2018, 04, 25), new DateTime(2018, 04, 27));
            _repo.AddClaimToDirectory(_claim);
        }
        [TestMethod]
        public void AddClaimToDirectory_ShouldReturnTrue()
        {
            Assert.IsTrue(_repo.AddClaimToDirectory(_claim));
        }
        [TestMethod]
        public void GetAllClaimsFromQueue_ShouldReturnTrue()
        {
            int initialCount = _repo.GetAllClaimsFromQueue().Count;
            Assert.AreEqual(initialCount, 1);
            Assert.AreNotEqual(initialCount, 2);
        }
        [TestMethod]
        public void PeekClaimsFromQueue_ShouldReturnTrue()
        {
            Assert.AreEqual(_claim, _repo.PeekClaimFromQueue());
        }
        [TestMethod]
        public void GetClaimsFromQueueById_ShouldReturnTrue()
        {
            ClaimsContent claim = _repo.GetClaimsFromQueueById(1);
            Assert.AreEqual(_claim, claim);
        }
        [TestMethod]
        public void UpdateExistingClaimById_ShouldReturnTrue()
        {
            _repo.UpdateExistingClaimById(1, new ClaimsContent(2, ClaimType.Home, "House fire in the kitchen", 4000.00m, new DateTime(2018, 04, 11), new DateTime(2018, 04, 12)));
            Assert.AreEqual(_claim.ClaimId, 2);
        }
        [TestMethod]
        public void DequeueFirstClaim_ShouldReturnTrue()
        {
            _repo.DequeueFirstClaim("y");
            int count = _repo.GetAllClaimsFromQueue().Count;
            Assert.AreEqual(0, count);
        }
    }
}
