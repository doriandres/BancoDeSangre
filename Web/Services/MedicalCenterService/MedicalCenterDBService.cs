using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BancoDeSangre.Models;
using BancoDeSangre.Services.DB;

namespace BancoDeSangre.Services.MedicalCenterService
{
    public class MedicalCenterDBService : DBService, IMedicalCenterService
    {
        public MedicalCenterDBService(DataBaseService dbservice) : base(dbservice) { }

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
    }
}