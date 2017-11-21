using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Assignment.Models
{
    public class Seller
    {
        public int Id { get; set; }
        [Required]
        public int SellerNumber { get; set; }
        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }
        [MaxLength(50)]
        public string Email { get; set; }
        [MaxLength(5)]
        public string CountryCode { get; set; }
        [MaxLength(100)]
        public string MobileNumber { get; set; }
        [Required]
        public bool IsDeleted { get; set; }

        [Display(Name = "Name")]
        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }

        [Display(Name = "Mobile Number")]
        public string MobileNumberWithCountryCode
        {
            get { return CountryCode + MobileNumber; }
        }

        public virtual ICollection<Seller2District> Seller2Districts { get; set; }

    }
}