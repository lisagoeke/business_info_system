using Assignment.Models;
using Assignment.Repos;
using Assignment.Repos.Interfaces;
using Assignment.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment.Services
{
    public class DistrictService : IDistrictService
    {
        private IDistrictRepository _districtRepo;
        private ISeller2DistrictRepository _seller2DistrictRepo;

        public DistrictService()
        {
            _districtRepo = new DistrictRepository();
            _seller2DistrictRepo = new Seller2DistrictRepository();
        }

        public IEnumerable<District> GetCurrentDistricts()
        {
            return _districtRepo.List();
        }

        public District GetDistrictById(int id)
        {
            var result = _districtRepo.Get(id);
            return result;
        }

        public bool InsertNewSeller2District(int districtId, int sellerId)
        {
            try
            {
                var seller2District = _seller2DistrictRepo.List()
                    .Where(x => x.DistrictId == districtId)
                    .FirstOrDefault();

                // already a row in Seller2District
                if (seller2District != null)
                {
                    //gets the primary for the district
                    var primaryForDistrict = _seller2DistrictRepo.List()
                        .Where(x => x.DistrictId == districtId && x.IsPrimary == true)
                        .FirstOrDefault();

                    if (primaryForDistrict != null)
                    {
                        //there is already a primary, insert all new as secondary
                        Seller2District newSeller2DistrictForPrimary = new Seller2District();
                        newSeller2DistrictForPrimary.DistrictId = districtId;
                        newSeller2DistrictForPrimary.SellerId = sellerId;
                        newSeller2DistrictForPrimary.IsPrimary = false;
                        newSeller2DistrictForPrimary.IsDeleted = false;
                        _seller2DistrictRepo.Insert(newSeller2DistrictForPrimary);
                    }
                    else
                    {
                        //no primary is given, insert new as primary to ensure that the district ALWAYS has one
                        Seller2District newSeller2DistrictForSecondary = new Seller2District();
                        newSeller2DistrictForSecondary.DistrictId = districtId;
                        newSeller2DistrictForSecondary.SellerId = sellerId;
                        newSeller2DistrictForSecondary.IsPrimary = true;
                        newSeller2DistrictForSecondary.IsDeleted = false;
                        _seller2DistrictRepo.Insert(newSeller2DistrictForSecondary);
                    }
                    _seller2DistrictRepo.SaveChanges();
                }
                else
                {
                    // no row in Seller2District, insert new one as primary
                    Seller2District newSeller2District = new Seller2District();
                    newSeller2District.DistrictId = districtId;
                    newSeller2District.SellerId = sellerId;
                    newSeller2District.IsPrimary = true;
                    newSeller2District.IsDeleted = false;
                    _seller2DistrictRepo.Insert(newSeller2District);
                    _seller2DistrictRepo.SaveChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool ChangePrimarySeller(int districtId, int sellerId)
        {
            List<Seller2District> currentPrimarySellers = _seller2DistrictRepo.List()
                .Where(x => x.DistrictId == districtId && x.IsPrimary == true)
                .ToList();

            if (currentPrimarySellers.Count == 1)
            {
                Seller2District currentPrimarySeller = currentPrimarySellers
                    .First();

                //update the current primary seller row to be deleted
                currentPrimarySeller.IsDeleted = true;
                _seller2DistrictRepo.Update(currentPrimarySeller);
                _seller2DistrictRepo.SaveChanges();

                //update the new primary seller's old row to be deleted
                var secondarySeller = _seller2DistrictRepo.List()
                   .Where(x => x.DistrictId == districtId && x.SellerId == sellerId)
                   .First();

                secondarySeller.IsDeleted = true;
                _seller2DistrictRepo.Update(secondarySeller);
                _seller2DistrictRepo.SaveChanges();

                //insert a new row for the seller to be a secondary
                Seller2District newSeller2District = new Seller2District();
                newSeller2District.SellerId = currentPrimarySeller.SellerId;
                newSeller2District.DistrictId = currentPrimarySeller.DistrictId;
                newSeller2District.IsDeleted = false;
                newSeller2District.IsPrimary = false;
                _seller2DistrictRepo.Insert(newSeller2District);
                _seller2DistrictRepo.SaveChanges();

                //insert a new row with the new primary seller
                Seller2District newPrimarySeller2District = new Seller2District();
                newPrimarySeller2District.SellerId = sellerId;
                newPrimarySeller2District.DistrictId = districtId;
                newPrimarySeller2District.IsPrimary = true;
                newPrimarySeller2District.IsDeleted = false;
                _seller2DistrictRepo.Insert(newPrimarySeller2District);
                _seller2DistrictRepo.SaveChanges();

                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteSeller(int districtId, int sellerId)
        {
            List<Seller2District> seller2Districts = _seller2DistrictRepo.List()
                .Where(x => x.DistrictId == districtId && x.SellerId == sellerId)
                .ToList();

            if (seller2Districts.Count == 1)
            {
                var seller2District = seller2Districts.First();
                seller2District.IsDeleted = true;
                _seller2DistrictRepo.Update(seller2District);
                _seller2DistrictRepo.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}