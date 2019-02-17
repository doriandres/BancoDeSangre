using System;
using BancoDeSangre.Enums;
using BancoDeSangre.Interfaces;

namespace BancoDeSangre.Models
{
    public class Donation : IEntity, IBloodTypable, IMeasurable
    {
        public int Id { get; set; }
        public BloodType BloodType { get; set; }
        public double Amount { get; set; }
        public MeasurementUnit Unit { get; set; }
        public DateTime Date { get; set; }
        public int DonorId { get; set; }
        public Donor Donor { get; set; }        
    }
}