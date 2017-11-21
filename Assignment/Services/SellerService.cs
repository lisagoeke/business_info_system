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
    public class SellerService : ISellerService
    {
        private ISellerRepository _sellerRepo;
        private ISeller2DistrictRepository _seller2DistrictRepo;

        public SellerService()
        {
            _sellerRepo = new SellerRepository();
            _seller2DistrictRepo = new Seller2DistrictRepository();
        }

        public SellerService(ISellerRepository sellerRepo, ISeller2DistrictRepository seller2DistrictRepo)
        {
            _sellerRepo = sellerRepo;
            _seller2DistrictRepo = seller2DistrictRepo;
        }

        public ICollection<Seller> GetAllCurrentUnassignedSellers(int id)
        {
            List<Seller> sellers = new List<Seller>();
            var assignedSellerIds = _seller2DistrictRepo.List()
                .Where(x => x.DistrictId == id && x.IsDeleted == false)
                .Select(x => x.SellerId).ToList();

            sellers = _sellerRepo.List()
                .Where(x => !assignedSellerIds.Contains(x.Id))
                .OrderBy(x => x.FullName)
                .ToList();

            return sellers;
        }

        public ICollection<Seller> GetCurrentSellersByDistrictId(int id)
        {
            List<Seller> sellers = new List<Seller>();
            var result = _seller2DistrictRepo.List()
                .Where(x => x.DistrictId == id).OrderBy(x => x.IsPrimary)
                .Select(x => x.SellerId);

            foreach (int r in result)
            {
                var seller = _sellerRepo.Get(r);
                sellers.Add(seller);
            }

            return sellers;
        }

        public Seller GetCurrentPrimarySellerByDistrictId(int id)
        {
            var sellerId = _seller2DistrictRepo.List()
                .Where(x => x.DistrictId == id && x.IsPrimary == true)
                .Select(x => x.SellerId)
                .FirstOrDefault();

            var seller = _sellerRepo.Get(sellerId);
            return seller;
        }

        public ICollection<Seller> GetCurrentSecondarySellersByDistrictId(int id)
        {
            List<Seller> sellers = new List<Seller>();
            var result = _seller2DistrictRepo.List()
                .Where(x => x.DistrictId == id && x.IsPrimary == false)
                .Select(x => x.SellerId);

            foreach (int r in result)
            {
                var seller = _sellerRepo.Get(r);
                sellers.Add(seller);
            }

            return sellers;
        }

        public Seller GetSellerByDistrictAndSellerId(int districtId, int sellerId)
        {
            Seller seller = null;
            var result = _seller2DistrictRepo.List()
                .Where(x => x.DistrictId == districtId && x.SellerId == sellerId)
                .ToList();

            if(result.Count == 1)
            {
                seller = _sellerRepo.Get(sellerId);
                if (seller != null)
                {
                    return seller;
                }
            }
            return null;
        }
    }
}