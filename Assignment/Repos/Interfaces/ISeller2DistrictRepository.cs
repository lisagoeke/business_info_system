using Assignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Repos.Interfaces
{
    public interface ISeller2DistrictRepository
    {
        /// <summary>
        /// Gets all seller 2 district relations that arenot marked deleted
        /// </summary>
        /// <returns>List of seller2districts</returns>
        IEnumerable<Seller2District> List();

        /// <summary>
        /// Inserts a seller 2 district relation
        /// </summary>
        /// <param name="seller2District">the seller2District to be inserted</param>
        void Insert(Seller2District seller2District);

        /// <summary>
        /// Updates a seller 2 district relation
        /// </summary>
        /// <param name="seller2District">The seller2District to be updated</param>
        void Update(Seller2District seller2District);

        /// <summary>
        /// Saves the changes
        /// </summary>
        void SaveChanges();
    }
}
