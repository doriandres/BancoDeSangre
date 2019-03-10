using System.Linq;
using BancoDeSangre.Models;
using BancoDeSangre.Services.DB;

namespace BancoDeSangre.Services.DonorService
{
    public class DonorDBService : DBService, IDonorService
    {
        public DonorDBService(DataBaseService dbservice) : base(dbservice) { }

        public bool CreateDonor(Donor donor)
        {
            dataBase.Donors.Add(donor);
            var countChanges = dataBase.SaveChanges();
            return true;
        }

        public Donor FindByID(int id)
        {
            return dataBase.Donors.FirstOrDefault(donor => donor.Id == id);
        }
    }
}