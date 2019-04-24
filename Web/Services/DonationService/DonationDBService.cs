using System;
using System.Collections.Generic;
using BancoDeSangre.Models;
using BancoDeSangre.Services.DB;
using System.Linq;
using BancoDeSangre.Services.ManagerService;

namespace BancoDeSangre.Services.DonationService
{
	public class DonationDBService : DBService, IDonationService
	{
		private IManagerService managerService;
		public DonationDBService(IDataBaseService dbservice, IManagerService managerService) : base(dbservice) {
			this.managerService = managerService;
		}

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

			if (donation.Date > DateTime.Today)
			{
				cause = "No puede recibir donaciones en el futuro";
				valid = false;
			}

			if (donation.Amount > 450)
			{
				cause = "No puede recibir donaciones mayores a medio litro (450 cc o 450 mL)";
				valid = false;
			}

            if (donation.Amount <= 0)
            {
                cause = "Debe ingresar una cantidad v\u00e1lida";
                valid = false;
            }

            if (donation.DonorId == 0)
			{
				cause = "Donante inv\u00E1lido";
				valid = false;
			}

            //Goes through de donor database to check id the donor ID is registered
			var found = false;
			foreach (Donor donor in dataBase.Donors)
			{
				if(donor.Id == donation.DonorId)
				{
					found = true;
				}
			}

            //If the ID of the donor is not found in the database
			if (!found)
			{
				cause = "El ID del donador no existe";
				valid = false;
			}

			return valid;
		}

		public List<Donation> FindAll()
		{
			var results = dataBase.Donations.ToList();
			results.Reverse();
			return results;
		}
	}
}
