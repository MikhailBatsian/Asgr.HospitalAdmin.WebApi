using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Asgr.HospitalAdmin.Domain.Patients.Entities;

namespace Asgr.HospitalAdmin.Persistence.Configurations;

public class PatientConfiguration : BaseEntityConfiguration<Patient>
{
    public override void Configure(EntityTypeBuilder<Patient> builder)
    {
        builder.Property(p => p.BirthDate)
            .IsRequired();

        builder.HasOne(p => p.Name)
            .WithOne(n => n.Patient)
            .HasForeignKey<HumanName>(n => n.PatientId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
