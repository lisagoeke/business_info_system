using Assignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Services.Interfaces
{
    public interface IShopService
    {
        /// <summary>
        /// Gets a collection of shops for a district Id
        /// </summary>
        /// <param name="id">The district Id</param>
        /// <returns>ICollection of shops</returns>
        ICollection<Shop> GetShopsByDistrictId(int id);
    }
}
