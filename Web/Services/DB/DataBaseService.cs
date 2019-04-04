using BancoDeSangre.Models;
using Microsoft.EntityFrameworkCore;

namespace BancoDeSangre.Services.DB
{  
    public class DataBaseService : DbContext, IDataBaseService
    {
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Campaign> Campaigns { get; set; }
        public DbSet<Donor> Donors { get; set; }
        public DbSet<MedicalCenter> MedicalCenters { get; set; }
        public DbSet<Donation> Donations { get; set; }
        public DbSet<BloodRequest> BloodRequests { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=localhost;Initial Catalog=Banco_de_sangre;Trusted_Connection=True;");
        }
    }
}