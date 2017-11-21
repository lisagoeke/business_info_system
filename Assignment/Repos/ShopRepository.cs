using Assignment.DAL;
using Assignment.Models;
using Assignment.Repos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment.Repos
{
    public class ShopRepository : IShopRepository
    {
        private AssignmentContext _dbContext = new AssignmentContext();

        public IEnumerable<Shop> List()
        {
            return _dbContext.Shops.Where(x => x.IsDeleted == false);
        }

        public Shop Get(int Id)
        {
            return _dbContext.Shops.Where(x => x.IsDeleted == false && x.Id == Id).FirstOrDefault();
        }
    }
}