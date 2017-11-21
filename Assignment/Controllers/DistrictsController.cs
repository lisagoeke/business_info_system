using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Assignment.DAL;
using Assignment.Models;
using Assignment.Services.Interfaces;
using Assignment.Services;
using Assignment.Repos;
using Assignment.ViewModels;

namespace Assignment.Controllers
{
    public class DistrictsController : Controller
    {
        private IDistrictService _districtService;
        private ISellerService _sellerService;
        private IShopService _shopService;

        public DistrictsController()
        {
            _districtService = new DistrictService();
            _sellerService = new SellerService();
            _shopService = new ShopService();
        }


        public ActionResult Index()
        {
            return View(_districtService.GetCurrentDistricts());
        }

        // GET: Districts/Details/5
        public ActionResult Details(int id)
        {
            var vmDistrict = new DistrictVM();
            var district = _districtService.GetDistrictById(id);
            vmDistrict.DistrictId = id;
            vmDistrict.PrimarySeller = _sellerService.GetCurrentPrimarySellerByDistrictId(id);
            vmDistrict.SecondarySellers = _sellerService.GetCurrentSecondarySellersByDistrictId(id);
            vmDistrict.Shops = _shopService.GetShopsByDistrictId(id);

            return View(vmDistrict);
        }
        public ActionResult AddSeller(int id)
        {
            var viewModel = new AddSellerVM();
            viewModel.DistrictId = id;
            viewModel.Sellers = _sellerService.GetAllCurrentUnassignedSellers(id);
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddSeller(AddSellerVM viewModel)
        {
            if (ModelState.IsValid)
            {
                var success = _districtService.InsertNewSeller2District(viewModel.DistrictId, viewModel.SellerId);
                if (success)
                {
                    return RedirectToAction("Details", new { id = viewModel.DistrictId });
                }
            }
            viewModel.Sellers = _sellerService.GetAllCurrentUnassignedSellers(viewModel.DistrictId);
            return View(viewModel);
        }

        public ActionResult RemoveSeller(int districtId, int sellerId)
        {
            RemoveSellerVM viewModel = new RemoveSellerVM();
            viewModel.DistrictId = districtId;
            viewModel.SellerId = sellerId;
            viewModel.Seller = _sellerService.GetSellerByDistrictAndSellerId(districtId, sellerId);
            return View(viewModel);
        }

        [HttpPost, ActionName("RemoveSeller")]
        [ValidateAntiForgeryToken]
        public ActionResult RemoveSellerConfirmed(RemoveSellerVM viewModel)
        {
            //Primary seller can't be deleted, check!
            var success = _districtService.DeleteSeller(viewModel.DistrictId, viewModel.SellerId);
            if (success)
            {
                var sellers = _sellerService.GetCurrentSellersByDistrictId(viewModel.DistrictId).ToList();
                if (sellers.Count > 0)
                {
                    return RedirectToAction("Details", new { id = viewModel.DistrictId });
                }
            }
            viewModel.Seller = _sellerService.GetSellerByDistrictAndSellerId(viewModel.DistrictId, viewModel.SellerId);
            return View(viewModel);
        }

        public ActionResult ChangePrimarySeller(int id)
        {
            ChangePrimaryVM viewModel = new ChangePrimaryVM();
            viewModel.DistrictId = id;
            viewModel.Sellers = _sellerService.GetCurrentSecondarySellersByDistrictId(id);
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangePrimarySeller(ChangePrimaryVM viewModel)
        {
            if (ModelState.IsValid)
            {
                var success = _districtService.ChangePrimarySeller(viewModel.DistrictId, viewModel.SellerId);
                if (success)
                {
                    return RedirectToAction("Details", new { id = viewModel.DistrictId });
                }
            }
            viewModel.Sellers = _sellerService.GetCurrentSecondarySellersByDistrictId(viewModel.DistrictId);
            return View(viewModel);
        }
    }
}

