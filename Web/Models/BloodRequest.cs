using BancoDeSangre.Enums;
using BancoDeSangre.Interfaces;

namespace BancoDeSangre.Models
{
    public class BloodRequest : IEntity, IBloodTypable, IMeasurable
    {
        public int Id { get; set; }
        public BloodType BloodType { get; set; }
        public double Amount { get; set; }
        public MeasurementUnit Unit { get; set; }
        public int MedicalCenterId { get; set; }
        public MedicalCenter MedicalCenter { get; set; }
    }
}