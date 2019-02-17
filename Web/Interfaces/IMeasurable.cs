using BancoDeSangre.Enums;

namespace BancoDeSangre.Interfaces
{
    public interface IMeasurable
    {
        double Amount { get; set; }
        MeasurementUnit Unit { get; set; }
    }
}
