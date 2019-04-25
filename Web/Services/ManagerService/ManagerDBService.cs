using System.Collections.Generic;
using System.Linq;
using BancoDeSangre.Models;
using BancoDeSangre.Services.DB;

namespace BancoDeSangre.Services.ManagerService
{
    public class ManagerDBService : DBService , IManagerService
    {   
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="dataBase"></param>
        public ManagerDBService(IDataBaseService dataBase) : base(dataBase)
        {
        }

        /// <summary>
        /// Creates a Manager in DataBase
        /// </summary>
        /// <param name="manager">Manager to create</param>
        /// <returns>Task which result is the Manager created</returns>
        public bool CreateManager(Manager manager)
        {
            dataBase.Managers.Add(manager);
            var countChanges = dataBase.SaveChanges();
            return countChanges > 0;
        }

        /// <summary>
        /// Shows all Managers
        /// </summary>
        /// <returns>List of Managers</returns>
        public List<Manager> FindAll()
        {
            return dataBase.Managers.ToList();
        }

        public Manager FindManagerByEmail(string email)
        {
            return dataBase.Managers.FirstOrDefault(m => m.Email == email);
        }


        /// <summary>
        /// Removes a Manager by its email
        /// </summary>
        /// <param name="email">Email</param>
        /// <returns></returns>
        public bool RemoveManagerByEmail(string email)
        {
            var rowsToRemove = dataBase.Managers.Where(manager => manager.Email == email);
            dataBase.Managers.RemoveRange(rowsToRemove);
            var countChanges = dataBase.SaveChanges();
            return countChanges > 0;
        }

        /// <summary>
        /// Finds a manager by its ID
        /// </summary>
        /// <param name="id">Manager ID</param>
        /// <returns>Manager found</returns>
        public Manager FindManagerById(int id)
        {
            return dataBase.Managers.FirstOrDefault(m => m.Id == id);
        }

    }
}