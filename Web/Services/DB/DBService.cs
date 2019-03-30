namespace BancoDeSangre.Services.DB
{
    public abstract class DBService
    {
        protected IDataBaseService dataBase;

        protected DBService(IDataBaseService dataBase)
        {
            this.dataBase = dataBase;
        }
    }
}