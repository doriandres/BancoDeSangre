using System.Collections.Generic;
using BancoDeSangre.Models;

namespace BancoDeSangre.Services.DonorService
{
    public interface IDonorService
    {
        bool CreateDonor(Donor donor);
        
        Donor FindByID(int id);

        bool IsValidDonor(Donor donor, out string cause);

        List<Donor> FindAll();
    }
}
