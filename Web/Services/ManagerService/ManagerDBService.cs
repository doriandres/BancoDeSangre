using System.Linq;
using BancoDeSangre.Models;
using BancoDeSangre.Services.DB;
using Microsoft.EntityFrameworkCore;

namespace BancoDeSangre.Services.ManagerService
{
    public class ManagerDBService : DBService , IManagerService
    {
        private DbSet<Manager> managersTable;

        public ManagerDBService(DataBaseService dataBase) : base(dataBase)
        {
            managersTable = dataBase.Managers;
        }

        public bool CreateManager(Manager manager)
        {
            managersTable.Add(manager);
            var countChanges = dataBase.SaveChanges();
            return countChanges > 0;
        }

        public Manager FindManagerByEmail(string email)
        {
            return managersTable.FirstOrDefault(manager => manager.Email == email);
        }

        public bool RemoveManagerByEmail(string email)
        {
            var rowsToRemove = managersTable.Where(manager => manager.Email == email);
            managersTable.RemoveRange(rowsToRemove);
            var countChanges = dataBase.SaveChanges();
            return countChanges > 0;
        }
    }
}