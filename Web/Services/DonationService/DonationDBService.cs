using System;
using BancoDeSangre.Models;
using BancoDeSangre.Services.DB;
using System.Linq;

namespace BancoDeSangre.Services.DonationService
{
    public class DonationDBService : DBService, IDonationService
    {
        public DonationDBService(IDataBaseService dbservice) : base(dbservice) { }

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

        public bool IsValidDonation(Donation donation, out string cause)
        {
            var valid = true;
            cause = "";

            //Se puede agregar una validacion sobre el tipo de sangre O- para que lo guarde como donador especial

            if (donation.Date > DateTime.Today)
            {
                cause = "No puede recibir donaciones en el futuro";
                valid = false;
            }

            if (donation.Amount > 500)
            {
                cause = "No puede recibir donaciones mayores a medio litro (500 cc o 500 mL)";
                valid = false;
            }

            if (donation.DonorId == 0)
            {
                cause = "Donante inválido";
                valid = false;
            }

            return valid;
        }
    }
}
