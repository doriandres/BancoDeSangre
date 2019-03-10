using BancoDeSangre.Models;
using BancoDeSangre.Services.DB;
using System.Linq;

namespace BancoDeSangre.Services.DonationService
{
    public class DonationDBService : DBService, IDonationService
    {
        public DonationDBService(DataBaseService dbservice) : base(dbservice) { }

        public bool CreateDonation(Donation donation)
        {
            dataBase.Donations.Add(donation);
            var countChanges = dataBase.SaveChanges();
            return true;
        }

        public Donation FindByID(int id)
        {
            return dataBase.Donations.FirstOrDefault(donation => donation.Id == id);
        }
    }
}