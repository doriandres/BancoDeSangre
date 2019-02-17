using System.Collections.Generic;
using BancoDeSangre.Interfaces;

namespace BancoDeSangre.Models
{
    public class Manager : IEntity, IPerson
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public List<Campaign> Campaigns { get; set; }        
    }
}