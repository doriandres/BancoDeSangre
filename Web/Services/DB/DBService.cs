namespace BancoDeSangre.Services.DB
{
    public abstract class DBService
    {
        protected DataBaseService dataBase;

        protected DBService(DataBaseService dataBase)
        {
            this.dataBase = dataBase;
        }
    }
}