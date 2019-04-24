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
            //optionsBuilder.UseSqlServer(@"Server=tcp:bancosangre.database.windows.net,1433;Initial Catalog=Banco_de_sangre;Persist Security Info=False;User ID=bancosangre;Password=Windows10;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }
    }
}
