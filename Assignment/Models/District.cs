using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Assignment.Models
{
    public class District
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        [Display(Name = "District Name")]
        public string Name { get; set; }
        [Required]
        [MaxLength(5)]
        [Display(Name="ISO Code")]
        public string ISOCode { get; set; }
        public double? Population { get; set; }
        [Required]
        public bool IsDeleted { get; set; }

        public virtual ICollection<Shop> Shops { get; set; }
        public virtual ICollection<Seller2District> Seller2District { get; set; }

    }
}