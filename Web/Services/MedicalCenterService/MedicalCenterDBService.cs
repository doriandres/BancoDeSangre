using System.Collections.Generic;
using System.Linq;
using BancoDeSangre.Models;
using BancoDeSangre.Services.DB;
using BancoDeSangre.Services.ManagerService;

namespace BancoDeSangre.Services.MedicalCenterService
{
    public class MedicalCenterDBService : DBService, IMedicalCenterService
    {
        private IManagerService managerService;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="dataBaseService"></param>
        /// <param name="managerService"></param>
        public MedicalCenterDBService(IDataBaseService dataBaseService, IManagerService managerService) : base(dataBaseService)
        {
            this.managerService = managerService;
        }

        /// <summary>
        /// Adds a medical center to DB
        /// </summary>
        /// <param name="medicalCenter">Medical Center to be created</param>
        /// <returns>Result of the creation of the Medical Center</returns>
        public bool CreateMedicalCenter(MedicalCenter medicalCenter)
        {
            dataBase.MedicalCenters.Add(medicalCenter);
            var countChanges = dataBase.SaveChanges();
            return true;
        }

        /// <summary>
        /// Finds a Medical Center by ID
        /// </summary>
        /// <param name="id">ID of the desired Medical Center</param>
        /// <returns>Found Medical Center search result</returns>
        public MedicalCenter FindByID(int id)
        {
            return dataBase.MedicalCenters.FirstOrDefault(medicalCenter => medicalCenter.Id == id);
        }

        /// <summary>
        /// Shows all the Medical Centers as a list
        /// </summary>
        /// <returns>List of all Medical Centers</returns>
        public List<MedicalCenter> FindAll()
        {
            var results = dataBase.MedicalCenters.ToList();
            results.Reverse();
            return results;
        }

        /// <summary>
        /// Checks if the Medical Center information is valid
        /// </summary>
        /// <param name="medicalCenter"></param>
        /// <param name="cause"></param>
        /// <returns></returns>
        public bool IsValid(MedicalCenter medicalCenter, out string cause)
        {
            var valid = true;
            cause = null;

            if (medicalCenter.Name.Trim().Length == 0)
            {
                cause = "Debe ingresar un nombre";
                valid = false;
            }

            if (medicalCenter.PhoneNumber < 20000000)
            {
                cause = "Debe ingresar un n\u00famero de tel\u00E9fono v\u00E1lido";
                valid = false;
            }

            if (medicalCenter.Email.Trim().Length == 0)
            {
                cause = "Debe ingresar un correo";
                valid = false;
            }

            if (medicalCenter.Place.Trim().Length == 0)
            {
                cause = "Debe ingresar una direccion v\u00E1lida";
                valid = false;
            }

            return valid;
        }
    }
}