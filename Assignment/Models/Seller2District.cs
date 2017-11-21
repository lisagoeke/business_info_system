using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Assignment.Models
{
    public class Seller2District
    {
        public int Id { get; set; }
        [Required]
        public int SellerId { get; set; }
        [Required]
        public int DistrictId { get; set; }
        [Required]
        public bool IsPrimary { get; set; }
        [Required]
        public bool IsDeleted { get; set; }


        [ForeignKey("SellerId")]
        public virtual Seller Seller { get; set; }

        [ForeignKey("DistrictId")]
        public virtual District District { get; set; }
    }
}