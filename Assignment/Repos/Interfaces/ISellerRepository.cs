using Assignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Repos.Interfaces
{
    public interface ISellerRepository
    {
        /// <summary>
        /// Gets all sellers that are not marked deleted
        /// </summary>
        /// <returns>List of sellers</returns>
        IEnumerable<Seller> List();

        /// <summary>
        /// Gets a seller by Id that is not marked deleted
        /// </summary>
        /// <param name="Id">the seller Id</param>
        /// <returns>Seller or default</returns>
        Seller Get(int Id);
    }
}
