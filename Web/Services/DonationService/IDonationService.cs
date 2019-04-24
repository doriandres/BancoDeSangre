using System.Collections.Generic;
using BancoDeSangre.Models;

namespace BancoDeSangre.Services.DonationService
{
    public interface IDonationService
    {
        bool CreateDonation(Donation donation);

        Donation FindByID(int id);

        bool IsValidDonation(Donation donation, out string cause);

        List<Donation> FindAll();

    }
}
