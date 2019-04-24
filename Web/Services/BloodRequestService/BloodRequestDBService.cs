using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BancoDeSangre.Models;
using BancoDeSangre.Services.DB;
using BancoDeSangre.Services.ManagerService;

namespace BancoDeSangre.Services.BloodRequestService
{
    public class BloodRequestDBService : DBService, IBloodRequestService
    {
        private IManagerService managerService;
        public BloodRequestDBService(IDataBaseService dataBase, IManagerService managerService) : base(dataBase)
        {
            this.managerService = managerService;
        }

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

        public bool IsValid(BloodRequest bloodRequest, out string cause)
        {
            var valid = true;
            cause = null;

            if (bloodRequest.Amount == 0)
            {
                cause = "No puede ingresar donaciones vacias";
                valid = false;
            }

            if (bloodRequest.MedicalCenterId == 0)
            {
                cause = "Debe ingresar un n\u00famero de identifiacion de centro medico v\u00E1lido";
                valid = false;
            }

            if (bloodRequest.MedicalCenter == null)
            {
                cause = "Debe ingresar un centro medico v\u00E1lido";
                valid = false;
            }

            if (bloodRequest.Id == 0)
            {
                cause = "Debe ingresar una ID v\u00E1lida";
                valid = false;
            }

            var found = false;
            foreach (MedicalCenter medicalCenter in dataBase.MedicalCenters)
            {
                if(medicalCenter.Id == bloodRequest.MedicalCenterId)
                {
                    found = true;
                }
            }

            if (!found)
            {
                cause = "El centro medico indicado no se encuentra registrado";
                valid = false;
            }

            return valid;
        }
    }
}