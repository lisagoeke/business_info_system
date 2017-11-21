using Assignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment.ViewModels
{
    public class RemoveSellerVM
    {
        public int SellerId { get; set; }
        public int DistrictId { get; set; }
        public Seller Seller { get; set; }
    }
}