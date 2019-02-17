using System.Collections.Generic;
using BancoDeSangre.Interfaces;

namespace BancoDeSangre.Models
{
    public class MedicalCenter : IEntity, IContact, ILocatable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public string Place { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public List<BloodRequest> BloodRequests { get; set; }
    }
}