using System;

namespace BancoDeSangre.Models
{
    public class Campaign
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Place { get; set; }
        public DateTime Date { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

    }
}