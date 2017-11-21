using Assignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment.ViewModels
{
    public class AddSellerVM
    {
        public int DistrictId { get; set; }
        public IEnumerable<Seller> Sellers { get; set; }
        public int SellerId { get; set; }
    }
}