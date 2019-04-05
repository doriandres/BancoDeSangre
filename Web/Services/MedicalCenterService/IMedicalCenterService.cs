using BancoDeSangre.Models;
using System.Collections.Generic;

namespace BancoDeSangre.Services.ManagerService
{
    public interface IMedicalCenterService
    {
        /// <summary>
        /// Adds a medical center to DB
        /// </summary>
        /// <param name="medicalCenter">Medical Center to be created</param>
        /// <returns>Result of the creation of the Medical Center</returns>
        bool CreateMedicalCenter(MedicalCenter medicalCenter);

        /// <summary>
        /// Finds a Medical Center by ID
        /// </summary>
        /// <param name="id">ID of the desired Medical Center</param>
        /// <returns>Found Medical Center search result</returns>
        MedicalCenter FindByID(int id);

        /// <summary>
        /// Shows all the Medical Centers as a list
        /// </summary>
        /// <returns>List of all Medical Centers</returns>
        List<MedicalCenter> FindAll();

        /// <summary>
        /// Requests a tyoe of blood
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        bool RequestBlood(BloodRequest request);

    }
}
