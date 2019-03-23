using BancoDeSangre.Models;
using Microsoft.EntityFrameworkCore;

namespace BancoDeSangre.Services.DB
{
    public interface IDataBaseService
    {
        DbSet<Manager> Managers { get; }
        DbSet<Campaign> Campaigns { get; }
        DbSet<Donor> Donors { get; }
        DbSet<MedicalCenter> MedicalCenters { get; }
        DbSet<Donation> Donations { get; }
        DbSet<BloodRequest> BloodRequests { get; }
        int SaveChanges();
    }
}