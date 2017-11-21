using Assignment.DAL;
using Assignment.Models;
using Assignment.Repos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment.Repos
{
    public class Seller2DistrictRepository : ISeller2DistrictRepository
    {
        private AssignmentContext _DbContext = new AssignmentContext();

        public IEnumerable<Seller2District> List()
        {
            return _DbContext.Seller2Districts.Where(x => x.IsDeleted == false).ToList();
        }
        public void SaveChanges()
        {
            _DbContext.SaveChanges();
        }
        public void Insert(Seller2District seller2District)
        {
            _DbContext.Seller2Districts.Add(seller2District);
        }
        public void Update(Seller2District seller2District)
        {
            _DbContext.Entry(seller2District).State = System.Data.Entity.EntityState.Modified;
        }
    }
}