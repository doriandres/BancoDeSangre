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

			if (donation.Amount > 500)
			{
				cause = "No puede recibir donaciones mayores a medio litro (500 cc o 500 mL)";
				valid = false;
			}

			if (donation.DonorId == 0)
			{
				cause = "Donante inv\u00E1lido";
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
