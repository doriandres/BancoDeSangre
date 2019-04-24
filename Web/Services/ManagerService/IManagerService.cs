using BancoDeSangre.Models;
using System.Collections.Generic;

namespace BancoDeSangre.Services.ManagerService
{
    public interface IManagerService
    {
        bool CreateManager(Manager manager);
        
        List<Manager> FindAll();
        
        Manager FindManagerById(int id);

        Manager FindManagerByEmail(string email);

        bool RemoveManagerByEmail(string email);
    }
}