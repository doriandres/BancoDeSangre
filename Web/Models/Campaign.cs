using System;
using BancoDeSangre.Interfaces;

namespace BancoDeSangre.Models
{
    public class Campaign : IEntity, ILocatable
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Place { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTime Date { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Description { get; set; }
        public int ManagerId { get; set; }
        public Manager Manager { get; set; }
    }
}