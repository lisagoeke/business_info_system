using Assignment.DAL;
using Assignment.Models;
using Assignment.Repos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment.Repos
{
    public class SellerRepository: ISellerRepository
    {
        private AssignmentContext _dbContext = new AssignmentContext();

        public IEnumerable<Seller> List()
        {
            return _dbContext.Sellers.Where(x => x.IsDeleted == false).ToList();
        }

        public Seller Get(int id)
        {
            return _dbContext.Sellers.Where(x => x.IsDeleted == false && x.Id == id).FirstOrDefault();
        }
    }
}