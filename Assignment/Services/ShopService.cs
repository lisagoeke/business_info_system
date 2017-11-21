using Assignment.Models;
using Assignment.Repos;
using Assignment.Repos.Interfaces;
using Assignment.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment.Services
{
    public class ShopService : IShopService
    {
        private IShopRepository _shopRepo;

        public ShopService()
        {
            _shopRepo = new ShopRepository();
        }

        public ShopService(IShopRepository repo)
        {
            _shopRepo = repo;
        }

        public ICollection<Shop> GetShopsByDistrictId(int id)
        {
            var result = _shopRepo.List()
                .Where(x => x.DistrictId == id)
                .ToList();

            return result;
        }
    }
}