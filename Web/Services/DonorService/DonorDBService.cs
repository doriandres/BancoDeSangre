using System;
using System.Collections.Generic;
using System.Linq;
using BancoDeSangre.Models;
using BancoDeSangre.Services.DB;
using BancoDeSangre.Services.ManagerService;

namespace BancoDeSangre.Services.DonorService
{
    public class DonorDBService : DBService, IDonorService
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        private IManagerService managerService;
        public DonorDBService(IDataBaseService dbservice, IManagerService managerService) : base(dbservice)
        {
            this.managerService = managerService;
        }

        /// <summary>
        /// Creates a Donor in DB
        /// </summary>
        /// <param name="donor">Donor to be added</param>
        /// <returns>Result of the creation of the donor</returns>
        public bool CreateDonor(Donor donor)
        {
            dataBase.Donors.Add(donor);
            var countChanges = dataBase.SaveChanges();
            return true;
        }

        /// <summary>
        /// Finds a donor by its ID in DB
        /// </summary>
        /// <param name="id">ID of the desired donor</param>
        /// <returns>The found donor</returns>
        public Donor FindByID(int id)
        {
            return dataBase.Donors.FirstOrDefault(donor => donor.Id == id);
        }

        /// <summary>
        /// Validates a Donor
        /// </summary>
        /// <param name="donor">Donor to validate</param>
        /// <param name="cause">Invalid cause</param>
        /// <returns>Results</returns>
        public bool IsValidDonor(Donor donor, out string cause)
        {
            var valid = true;
            cause = null;

            if (donor.Name.Trim().Length == 0)
            {
                cause = "Debe ingresar un nombre";
                valid = false;
            }

            if (donor.LastName.Trim().Length == 0)
            {
                cause = "Debe ingresar un apellido";
                valid = false;
            }

            if (donor.PhoneNumber < 20000000)
            {
                cause = "Debe ingresar un n\u00famero de tel\u00E9fono v\u00E1lido";
                valid = false;
            }

            if ((DateTime.Today.Year - donor.BornDate.Year) < 18)
            {
                cause = "No puede recibir donaciones de menores de edad";
                valid = false;
            }

            if (donor.Email.Trim().Length == 0)
            {
                cause = "Debe ingresar un correo";
                valid = false;
            }

            if (donor.Gender.Trim().Length == 0)
            {
                cause = "Debe ingresar un g\u00E9nero";
                valid = false;
            }

            if (donor.Height < 0 || donor.Height > 2.30)
            {
                cause = "Debe ingresar una altura v\u00e1lida";
                valid = false;
            }

            if (donor.Weight < 50)
            {
                cause = "No se permiten donaciones en pacientes con pesos menores a 50 kg";
                valid = false;
            }

            if (donor.Weight > 500)
            {
                cause = "Debe ingresar un peso v\u00e1lido";
                valid = false;
            }

            if (donor.Id < 100000000 & donor.Id > 999999999)
            {
                cause = "Debe ingresar un n\u00famero de identificaci\00f3n v\u00e1lido";
                valid = false;
            }

            foreach (Donor d in dataBase.Donors)
            {
                if (d.Email == donor.Email)
                {
                    cause = "Este correo ya se encuentra registrado";
                    valid = false;
                }
            }

            return valid;
        }

        /// <summary>
        /// Gets all donors registered to database
        /// </summary>
        /// <returns>Returns donors in DB as a List</returns>
        public List<Donor> FindAll()
        {
            var results = dataBase.Donors.ToList();
            results.Reverse();        
            return results;
        }
    }
}