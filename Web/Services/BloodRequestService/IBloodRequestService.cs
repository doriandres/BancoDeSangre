using BancoDeSangre.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoDeSangre.Services.BloodRequestService
{
    public interface IBloodRequestService
    {
        /// <summary>
        /// Adds a blood request to DB
        /// </summary>
        /// <param name="bloodRequest">Blood request to be added</param>
        /// <returns>Result of operation</returns>
        bool CreateBloodRequest(BloodRequest bloodRequest);

        /// <summary>
        /// Returns all the blood requests as a list
        /// </summary>
        /// <returns>list of blood requests</returns>
        List<BloodRequest> FindAll();

        /// <summary>
        /// Checks if the BloodRequest is valid
        /// </summary>
        /// <param name="bloodRequest"></param>
        /// <param name="cause"></param>
        /// <returns>Result of the operation</returns>
        bool IsValid(BloodRequest bloodRequest, out string cause);
    }
}
