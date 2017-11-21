using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Assignment.Repos.Interfaces;
using Assignment.DAL;
using Assignment.Models;

namespace Assignment.Repos
{
    public class DistrictRepository : IDistrictRepository
    {
        private AssignmentContext _DbContext = new AssignmentContext();

        public IEnumerable<District> List()
        {
            return _DbContext.Districts.Where(x => x.IsDeleted == false).ToList();
        }

        public District Get(int Id)
        {
            return _DbContext.Districts.Where(x => x.IsDeleted == false && x.Id == Id).FirstOrDefault();
        }
    }

}