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
        bool CreateBloodRequest(BloodRequest bloodRequest);
        
        List<BloodRequest> FindAll();

        bool IsValid(BloodRequest bloodRequest, out string cause);
    }
}
