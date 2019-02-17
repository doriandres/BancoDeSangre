using System;
using System.Collections.Generic;
using BancoDeSangre.Enums;
using BancoDeSangre.Interfaces;

namespace BancoDeSangre.Models
{
    public class Donor : IEntity, IPerson, IContact, IBloodTypable
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string SecondLastName { get; set; }
        public DateTime BornDate { get; set; }
        public string Gender { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public BloodType BloodType { get; set; }
        public List<Donation> Donations { get; set; }
    }
}