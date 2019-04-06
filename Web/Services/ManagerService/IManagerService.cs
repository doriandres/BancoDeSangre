using BancoDeSangre.Models;
using System.Collections.Generic;

namespace BancoDeSangre.Services.ManagerService
{
    public interface IManagerService
    {
        /// <summary>
        /// Creates a Manager in DataBase
        /// </summary>
        /// <param name="manager">Manager to create</param>
        /// <returns>Task which result is the Manager created</returns>
        bool CreateManager(Manager manager);
        
        /// <summary>
        /// Shows all Managers
        /// </summary>
        /// <returns>List of Managers</returns>
        List<Manager> FindAll();


        /// <summary>
        /// Finds a Manager by its ID
        /// </summary>
        /// <param name="id">Manager ID</param>
        /// <returns>Task which result is the Manager found</returns>
        Manager FindManagerById(int id);

        /// <summary>
        /// Finds a Manager by its email
        /// </summary>
        /// <param name="email">Email to seek</param>
        /// <returns>Task which result is the Manager found</returns>
        Manager FindManagerByEmail(string email);

        /// <summary>
        /// Removes a Manager by its email
        /// </summary>
        /// <param name="email">Email</param>
        /// <returns></returns>
        bool RemoveManagerByEmail(string email);
    }
}