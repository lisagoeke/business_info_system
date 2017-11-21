using Assignment.Repos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment.Models;

namespace Assignment.Tests.Mocks
{
    class ShopRepoMock : IShopRepository
    {
        public Shop Get(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Shop> List()
        {
            return new List<Shop>
            {
                new Shop() { Id = 3, BusinessId = "123", DistrictId = 234, IsDeleted = false, Name = "Shop 1" },
                new Shop() { Id = 4, BusinessId = "456", DistrictId = 345, IsDeleted = false, Name = "Shop 2" },
                new Shop() { Id = 5, BusinessId = "456", DistrictId = 234, IsDeleted = false, Name = "Shop 3" },
            };
        }
    }
}
