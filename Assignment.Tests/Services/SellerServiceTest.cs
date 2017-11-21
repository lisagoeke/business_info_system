using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assignment.Tests.Mocks;
using Assignment.Services;
using System.Linq;
using Assignment.Models;

namespace Assignment.Tests.Services
{
    [TestClass]
    public class SellerServiceTest
    {
        private SellerService BuildService()
        {
            var sellerRepoMock = new SellerRepoMock();
            var seller2DistrictRepoMock = new Seller2DistrictRepoMock();
            var sellerService = new SellerService(sellerRepoMock, seller2DistrictRepoMock);

            return sellerService;
        }


        [TestMethod]
        public void TestGetCurrentSellersByDistrictId()
        {
            var result = BuildService().GetCurrentSellersByDistrictId(1);
            Assert.IsTrue(result.Any(s => s.SellerNumber == 12345), "The seller with number 12345 is returned");
            Assert.IsTrue(result.Any(s => s.SellerNumber == 23456), "The seller with number 23456 is returned");
            Assert.IsTrue(result.Any(s => s.SellerNumber == 34567), "The seller with number 34567 is returned");
            Assert.IsFalse(result.Any(s => s.SellerNumber == 45678), "The seller with number 45678 is not returned");
            Assert.IsFalse(result.Any(s => s.SellerNumber == 56789), "The seller with number 56789 is not returned");
            Assert.IsFalse(result.Any(s => s.SellerNumber == 67890), "The seller with number 67890 is not returned");
        }

        [TestMethod]
        public void TestGetCurrentPrimarySellerByDistrictId()
        {
            var result = BuildService().GetCurrentPrimarySellerByDistrictId(1);
            Assert.IsTrue(result.SellerNumber == 12345, "The seller with number 12345 is returned");
            Assert.IsFalse(result.SellerNumber == 23456, "The seller with number 23456 is not returned");
            Assert.IsFalse(result.SellerNumber == 34567, "The seller with number 34567 is not returned");
        }

        [TestMethod]
        public void TestGetCurrentSecondarySellersByDistrictId()
        {
            var result = BuildService().GetCurrentSecondarySellersByDistrictId(1);
            Assert.IsTrue(result.Any(s => s.SellerNumber == 23456), "The seller with number 23456 is returned");
            Assert.IsTrue(result.Any(s => s.SellerNumber == 34567), "The seller with number 34567 is returned");
            Assert.IsFalse(result.Any(s => s.SellerNumber == 12345), "The seller with number 12345 is not returned");
        }

        [TestMethod]
        public void TestGetAllCurrentUnassignedSellers()
        {
            var result = BuildService().GetAllCurrentUnassignedSellers(1);
            Assert.IsTrue(result.Any(s => s.SellerNumber == 45678), "The seller with number 45678 is returned");
            Assert.IsTrue(result.Any(s => s.SellerNumber == 56789), "The seller with number 56789 is returned");
            Assert.IsTrue(result.Any(s => s.SellerNumber == 67890), "The seller with number 67890 is returned");
            Assert.IsFalse(result.Any(s => s.SellerNumber == 12345), "The seller with number 12345 is not returned");
            Assert.IsFalse(result.Any(s => s.SellerNumber == 23456), "The seller with number 23456 is not returned");
            Assert.IsFalse(result.Any(s => s.SellerNumber == 34567), "The seller with number 34567 is not returned");
        }

        [TestMethod]
        public void TestGetSellerByDistrictAndSellerId()
        {
            var result = BuildService().GetSellerByDistrictAndSellerId(1, 1);
            Assert.IsTrue(result.SellerNumber == 12345, "The seller with number 12345 is returned");
        }
    }
}
