using System.Collections.Generic;
using BancoDeSangre.Models;

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

        /// <summary>
        /// Validates a Donation
        /// </summary>
        /// <param name="donation">Donation to validate</param>
        /// <param name="cause">Invalid cause</param>
        /// <returns>Result</returns>
        bool IsValidDonation(Donation donation, out string cause);

        List<Donation> FindAll();

    }
}
