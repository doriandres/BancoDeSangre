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

    }
}
