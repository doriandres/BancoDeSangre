namespace BancoDeSangre.Interfaces
{
    public interface ILocatable
    {
        string Place { get; set; }
        double Latitude { get; set; }
        double Longitude { get; set; }
    }
}
