using Assignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Services.Interfaces
{
    public interface IDistrictService
    {
        /// <summary>
        /// Gets all districts that are not marked deleted
        /// </summary>
        /// <returns>IEnumerable of districts</returns>
        IEnumerable<District> GetCurrentDistricts();

        /// <summary>
        /// Gets the district by Id
        /// </summary>
        /// <param name="id">The district Id</param>
        /// <returns>A single district</returns>
        District GetDistrictById(int id);

        /// <summary>
        /// Inserts a new seller 2 district relation
        /// </summary>
        /// <param name="districtId">The district Id</param>
        /// <param name="sellerId">The seller Id</param>
        /// <returns>success or not</returns>
        bool InsertNewSeller2District(int districtId, int sellerId);

        /// <summary>
        /// Deletes a seller 2 district relation
        /// </summary>
        /// <param name="districtId">The district Id</param>
        /// <param name="sellerId">The seller Id</param>
        /// <returns>success or not</returns>
        bool DeleteSeller(int districtId, int sellerId);

        /// <summary>
        /// Changes the primary seller
        /// </summary>
        /// <param name="districtId">The district Id</param>
        /// <param name="sellerId">The seller Id</param>
        /// <returns>success or not</returns>
        bool ChangePrimarySeller(int districtId, int sellerId);
    }
}
