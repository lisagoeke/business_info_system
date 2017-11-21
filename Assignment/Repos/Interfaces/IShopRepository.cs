using Assignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Repos.Interfaces
{
    public interface IShopRepository
    {
        /// <summary>
        /// Gets all shops that are not marked deleted
        /// </summary>
        /// <returns>List of shops</returns>
        IEnumerable<Shop> List();

        /// <summary>
        /// Gets the shop by Id that is not marked deleted
        /// </summary>
        /// <param name="Id">The shop Id</param>
        /// <returns>Shop or default</returns>
        Shop Get(int Id);
    }
}
