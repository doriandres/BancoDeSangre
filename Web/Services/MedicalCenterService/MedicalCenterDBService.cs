using System.Collections.Generic;
using System.Linq;
using BancoDeSangre.Models;
using BancoDeSangre.Services.DB;
using BancoDeSangre.Services.ManagerService;

namespace BancoDeSangre.Services.MedicalCenterService
{
    public class MedicalCenterDBService : DBService, IMedicalCenterService
    {
        public MedicalCenterDBService(IDataBaseService dataBaseService) : base(dataBaseService)
        {
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
    }
}