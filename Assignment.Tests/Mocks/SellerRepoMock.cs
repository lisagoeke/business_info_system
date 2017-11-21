using Assignment.Repos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment.Models;

namespace Assignment.Tests.Mocks
{
    class SellerRepoMock : ISellerRepository
    {
        private List<Seller> data = new List<Seller>
            {
                new Seller()
                {
                    Id = 1, SellerNumber=12345, FirstName="Mikko", LastName= "Niemi", Email="test1@testmail.com",
                    CountryCode = "+358", MobileNumber="123456789", IsDeleted=false
                },
                new Seller()
                {
                    Id = 2, SellerNumber=23456, FirstName="Matti", LastName= "Jäntti", Email="test2@testmail.com",
                    CountryCode = "+358", MobileNumber="234567890", IsDeleted=false
                },
                new Seller()
                {
                    Id = 3, SellerNumber=34567, FirstName="Henna", LastName= "Nieminen", Email="test3@testmail.com",
                    CountryCode = "+358", MobileNumber="345678901", IsDeleted=false
                },
                new Seller()
                {
                    Id = 4, SellerNumber=45678, FirstName="Jaakko", LastName= "Alaspää", Email="test4@testmail.com",
                    CountryCode = "+358", MobileNumber="456789012", IsDeleted=false
                },
                new Seller()
                {
                    Id = 5, SellerNumber=56789, FirstName="Jukka", LastName= "Haapanen", Email="test5@testmail.com",
                    CountryCode = "+358", MobileNumber="567890123", IsDeleted=false
                },
                new Seller()
                {
                    Id = 6, SellerNumber=67890, FirstName="Veli-Pekka", LastName= "Kivistö", Email="test6@testmail.com",
                    CountryCode = "+358", MobileNumber="678901234", IsDeleted=false
                },
            };

        public Seller Get(int id)
        {
            var seller = data.Where(x => x.Id == id).FirstOrDefault();
            return seller;
        }

        public IEnumerable<Seller> List()
        {
            return data;
        }
    }
}
