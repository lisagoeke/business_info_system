using Assignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment.ViewModels
{
    public class ChangePrimaryVM
    {
        public int DistrictId { get; set; }
        public int SellerId { get; set; }
        public IEnumerable<Seller> Sellers { get; set; }
    }
}