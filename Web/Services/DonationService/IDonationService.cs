using BancoDeSangre.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoDeSangre.Services.DonationService
{
    public interface IDonationService
    {
        /// <summary>
        /// Adds a donation to the DB
        /// </summary>
        /// <param name="donation">Donation to be created</param>
        /// <returns>Result of the creation of the donation</returns>
        bool CreateDonation(Donation donation);

        /// <summary>
        /// Finds a donation by its ID
        /// </summary>
        /// <param name="id">ID of the desired donation</param>
        /// <returns>The found donation</returns>
        Donation FindByID(int id);
    }
}
