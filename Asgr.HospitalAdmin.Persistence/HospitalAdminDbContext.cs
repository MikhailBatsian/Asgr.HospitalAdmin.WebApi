using Asgr.HospitalAdmin.Domain.Patients.Entities;
using Asgr.HospitalAdmin.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Asgr.HospitalAdmin.Persistence;

public class HospitalAdminDbContext : DbContext
{
    public HospitalAdminDbContext(DbContextOptions<HospitalAdminDbContext> options)
        : base(options)
    {
    }

    public DbSet<Patient> Patients { get; set; }
    public DbSet<HumanName> HumanNames { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new PatientConfiguration());
        modelBuilder.ApplyConfiguration(new HumanNameConfiguration());
    }
}
