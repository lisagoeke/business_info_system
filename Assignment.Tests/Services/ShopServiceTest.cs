using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assignment.Services;
using Assignment.Tests.Mocks;
using System.Linq;

namespace Assignment.Tests.Services
{
    [TestClass]
    public class ShopServiceTest
    {
        private ShopService BuildService()
        {
            var mockRepo = new ShopRepoMock();
            var shopService = new ShopService(mockRepo);

            return shopService;
        }
        [TestMethod]
        public void TestGetShopsByDistrictId()
        {
            var result = BuildService().GetShopsByDistrictId(234);
            Assert.IsTrue(result.Any(s => s.Name == "Shop 1"), "Shop 1 is returned");
            Assert.IsTrue(result.Any(s => s.Name == "Shop 3"), "Shop 3 is returned");
            Assert.IsFalse(result.Any(s => s.Name == "Shop 2"), "Shop 2 is not returned");
        }
    }
}
