using Asgr.HospitalAdmin.Domain.Patients.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Asgr.HospitalAdmin.Persistence.Configurations;

public class HumanNameConfiguration : BaseEntityConfiguration<HumanName>
{
    public override void Configure(EntityTypeBuilder<HumanName> builder)
    {
        builder.Property(n => n.Use)
            .HasMaxLength(50);

        builder.Property(n => n.Family)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(n => n.Given)
            .HasColumnType("jsonb");
    }
}
