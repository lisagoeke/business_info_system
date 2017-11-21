using Assignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Repos.Interfaces
{
    public interface IDistrictRepository
    {
        /// <summary>
        /// Gets all districts that are not marked deleted
        /// </summary>
        /// <returns>List of Districts</returns>
        IEnumerable<District> List();

        /// <summary>
        /// Gets a district that is not mraked deleted by Id
        /// </summary>
        /// <param name="Id">The distict Id</param>
        /// <returns>District or default</returns>
        District Get(int Id);
    }
}
