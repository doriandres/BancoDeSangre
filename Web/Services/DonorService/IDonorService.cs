using BancoDeSangre.Models;

namespace BancoDeSangre.Services.DonorService
{
    public interface IDonorService
    {
        /// <summary>
        /// Creates a Donor in DB
        /// </summary>
        /// <param name="donor">Donor to be added</param>
        /// <returns>Result of the creation of the donor</returns>
        bool CreateDonor(Donor donor);

        /// <summary>
        /// Finds a donor by its ID in DB
        /// </summary>
        /// <param name="id">ID of the desired donor</param>
        /// <returns>The found donor</returns>
        Donor FindByID(int id);

        /// <summary>
        /// Validates a Donor
        /// </summary>
        /// <param name="donor">Donor to validate</param>
        /// <param name="cause">Invalid cause</param>
        /// <returns>Results</returns>
        bool IsValidDonor(Donor donor, out string cause);
        bool IsValidDonor(object cause);
    }
}
