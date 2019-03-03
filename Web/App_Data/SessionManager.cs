using System;
using System.Web;
using BancoDeSangre.Models;


namespace BancoDeSangre.App_Data
{
    public static class SessionManager
    {
        /// <summary>
        /// Key to use into the Session Dictionary
        /// </summary>
        private static string key = "Manager";

        /// <summary>
        /// Checks if a Manager is already Signed In
        /// </summary>
        /// <param name="session">Session</param>
        /// <returns>Result</returns>
        public static bool IsSignedIn(this HttpSessionStateBase session) => session[key] != null;

        /// <summary>
        /// Gets the Signed In Manager Instance
        /// </summary>
        /// <param name="session">Session</param>
        /// <returns>Signed In Manager</returns>
        public static Manager GetSignedInManager(this HttpSessionStateBase session)
        {
            try
            {
                return (Manager) session[key];
            }
            catch (Exception e)
            {
                return null;
            }
        }

        /// <summary>
        /// Sets the Signed In Manager
        /// </summary>
        /// <param name="session">Session</param>
        /// <param name="manager">Manager</param>
        public static void SetSignedInManager(this HttpSessionStateBase session, Manager manager) => session[key] = manager;

        /// <summary>
        /// Removes the existing Signed In Instance
        /// </summary>
        /// <param name="session">Session</param>
        public static void SignOut(this HttpSessionStateBase session) => session[key] = null;
    }
}