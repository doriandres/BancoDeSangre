using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BancoDeSangre.Models;
using BancoDeSangre.Services.DB;

namespace BancoDeSangre.Services.BloodRequestService
{
    public class BloodRequestDBService : DBService, IBloodRequestService
    {
        public BloodRequestDBService(IDataBaseService dataBase) : base(dataBase){}

        public bool CreateBloodRequest(BloodRequest bloodRequest)
        {
            dataBase.BloodRequests.Add(bloodRequest);
            var countChanges = dataBase.SaveChanges();
            return true;
        }

        public List<BloodRequest> FindAll()
        {
            return dataBase.BloodRequests.ToList();
        }
    }
}