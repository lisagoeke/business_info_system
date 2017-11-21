using Assignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment.ViewModels
{
    public class DistrictVM
    {
        public ICollection<Shop> Shops { get; set; }
        public Seller PrimarySeller { get; set; }
        public ICollection<Seller> SecondarySellers { get; set; }
        public int DistrictId { get; set; }
    }
}