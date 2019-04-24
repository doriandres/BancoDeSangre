using System.Collections.Generic;
using BancoDeSangre.Models;

namespace BancoDeSangre.Services.MedicalCenterService
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
        /// Checks if the Medical Center information is valid
        /// </summary>
        /// <param name="medicalCenter"></param>
        /// <param name="cause"></param>
        /// <returns></returns>
        bool IsValid(MedicalCenter medicalCenter, out string cause);

    }
}
