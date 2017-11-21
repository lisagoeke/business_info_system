using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Assignment.Models
{
    public class Shop
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(10)]
        [Display(Name="Business ID")]
        public string BusinessId { get; set; }
        [MaxLength(100)]
        [Display(Name="Shop Name")]
        public string Name { get; set; }
        [Required]
        public int DistrictId { get; set; }
        [Required]
        public bool IsDeleted { get; set; }


        [ForeignKey("DistrictId")]
        public virtual District District { get; set; }
    }
}