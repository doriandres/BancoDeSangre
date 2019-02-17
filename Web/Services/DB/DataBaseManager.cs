using BancoDeSangre.Models;
using Microsoft.EntityFrameworkCore;

namespace BancoDeSangre.Services
{  
    public class DataBaseService : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Campaign> Campaigns { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=tcp:bancosangre.database.windows.net,1433;Initial Catalog=Banco_de_sangre;Persist Security Info=False;User ID=bancosangre;Password=Windows10;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }
    }
}