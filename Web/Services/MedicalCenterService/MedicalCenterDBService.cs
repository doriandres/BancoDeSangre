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
        public MedicalCenterDBService(IDataBaseService dataBaseService, IManagerService managerService) : base(dataBaseService)
        {
            this.managerService = managerService;
        }

        public bool CreateMedicalCenter(MedicalCenter medicalCenter)
        {
            dataBase.MedicalCenters.Add(medicalCenter);
            var countChanges = dataBase.SaveChanges();
            return true;
        }

        public MedicalCenter FindByID(int id)
        {
            return dataBase.MedicalCenters.FirstOrDefault(medicalCenter => medicalCenter.Id == id);
        }

        public bool RequestBlood(BloodRequest request)
        {
            dataBase.BloodRequests.Add(request);
            var countChanges = dataBase.SaveChanges();
            return true;
        }

        public List<MedicalCenter> FindAll()
        {
            var results = dataBase.MedicalCenters.ToList();
            results.Reverse();
            return results;
        }

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

            if (medicalCenter.Id == 0)
            {
                cause = "Debe ingresar una ID v\u00E1lida";
                valid = false;
            }

            return valid;
        }
    }
}