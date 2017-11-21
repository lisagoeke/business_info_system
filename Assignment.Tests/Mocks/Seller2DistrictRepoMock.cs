using Assignment.Repos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment.Models;

namespace Assignment.Tests.Mocks
{
    class Seller2DistrictRepoMock : ISeller2DistrictRepository
    {
        public Seller2District Get(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Seller2District> List()
        {
            return new List<Seller2District>
            {
                new Seller2District() { DistrictId=1, SellerId=1, IsPrimary = true, IsDeleted = false},
                new Seller2District() { DistrictId=1, SellerId=2, IsPrimary = false, IsDeleted = false},
                new Seller2District() { DistrictId=1, SellerId=3, IsPrimary = false, IsDeleted = false}
            };
        }

        public void Insert(Seller2District seller2District)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void Update(Seller2District seller2District)
        {
            throw new NotImplementedException();
        }
    }
}
