using System.Collections.Generic;
using BancoDeSangre.Models;

namespace BancoDeSangre.Services.MedicalCenterService
{
    public interface IMedicalCenterService
    {
        bool CreateMedicalCenter(MedicalCenter medicalCenter);

        MedicalCenter FindByID(int id);

        List<MedicalCenter> FindAll();

        bool IsValid(MedicalCenter medicalCenter, out string cause);

    }
}
