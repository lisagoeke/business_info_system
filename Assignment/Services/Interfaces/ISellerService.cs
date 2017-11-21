using Assignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Services.Interfaces
{
    public interface ISellerService
    {
        /// <summary>
        /// Gets all currently unassigned sellers 
        /// </summary>
        /// <param name="id">The district Id</param>
        /// <returns>ICollection of Seller or default</returns>
        ICollection<Seller> GetAllCurrentUnassignedSellers(int id);

        /// <summary>
        /// Gets the current primary seller for a district
        /// </summary>
        /// <param name="id">The district Id</param>
        /// <returns>Seller or default</returns>
        Seller GetCurrentPrimarySellerByDistrictId(int id);

        /// <summary>
        /// Gets the current secondayr sellers for a district
        /// </summary>
        /// <param name="id">The district Id</param>
        /// <returns>ICollection of Seller or default</returns>
        ICollection<Seller> GetCurrentSecondarySellersByDistrictId(int id);

        /// <summary>
        /// Gets the sellers currently assigned to a district
        /// </summary>
        /// <param name="id">The district Id</param>
        /// <returns>ICollection of Seller or default</returns>
        ICollection<Seller> GetCurrentSellersByDistrictId(int id);

        /// <summary>
        /// Gets the seller by district and seller Id
        /// </summary>
        /// <param name="districtId">The district Id</param>
        /// <param name="sellerId">The seller Id</param>
        /// <returns>Seller or default</returns>
        Seller GetSellerByDistrictAndSellerId(int districtId, int sellerId);
    }
}
