using System.Linq;
using BancoDeSangre.Models;
using BancoDeSangre.Services.DB;


namespace BancoDeSangre.Services.ManagerService
{
    public class ManagerDBService : DBService , IManagerService
    {
        public ManagerDBService(DataBaseService dataBase) : base(dataBase)
        {
        }

        public bool CreateManager(Manager manager)
        {
            dataBase.Managers.Add(manager);
            var countChanges = dataBase.SaveChanges(); // Saves the Manager to Data Base
            return countChanges > 0;
        }

        public Manager FindByEmail(string email)
        {
            return dataBase.Managers.FirstOrDefault(manager => manager.Email == email);
        }

    }
}