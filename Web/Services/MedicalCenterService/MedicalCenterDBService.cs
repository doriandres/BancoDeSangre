using System.Collections.Generic;
using System.Linq;
using BancoDeSangre.Models;
using BancoDeSangre.Services.DB;

namespace BancoDeSangre.Services.ManagerService
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
            return dataBase.MedicalCenters.ToList();
        }
    }
}