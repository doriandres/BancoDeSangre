namespace BancoDeSangre.Services.DB
{
    public abstract class DBService
    {
        protected IDataBaseService dataBase;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="dataBase"></param>
        protected DBService(IDataBaseService dataBase)
        {
            this.dataBase = dataBase;
        }
    }
}