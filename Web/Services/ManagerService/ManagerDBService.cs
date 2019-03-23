using System.Linq;
using BancoDeSangre.Models;
using BancoDeSangre.Services.DB;

namespace BancoDeSangre.Services.ManagerService
{
    public class ManagerDBService : DBService , IManagerService
    {        
        public ManagerDBService(IDataBaseService dataBase) : base(dataBase)
        {
        }

        public bool CreateManager(Manager manager)
        {
            dataBase.Managers.Add(manager);
            var countChanges = dataBase.SaveChanges();
            return countChanges > 0;
        }

        public Manager FindManagerByEmail(string email)
        {
            return dataBase.Managers.FirstOrDefault(m => m.Email == email);
        }

        public bool RemoveManagerByEmail(string email)
        {
            var rowsToRemove = dataBase.Managers.Where(manager => manager.Email == email);
            dataBase.Managers.RemoveRange(rowsToRemove);
            var countChanges = dataBase.SaveChanges();
            return countChanges > 0;
        }

        public Manager FindManagerById(int id)
        {
            return dataBase.Managers.FirstOrDefault(m => m.Id == id);
        }

    }
}