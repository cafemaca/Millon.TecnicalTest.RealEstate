// ****************************************************************
//  Assembly         : Millon.TecnicalTest.RealEstate.Data
//  Author           :  Carlos Fernando Malagón Cano
//  Created          : 01-09-2025
//
//  Last Modified By : Carlos Fernando Malagón Cano
//  Last Modified On : 01-09-2025
//  ****************************************************************
//  <copyright file="ApplicationDbContext.cs"
//      company="Cafemaca - CAFEMACA Colombia">
//      Cafemaca - CAFEMACA Colombia
//  </copyright>
//


using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Millon.TecnicalTest.RealEstate.Domain.Common.ModelConstants;
using Millon.TecnicalTest.RealEstate.Domain.Entities.Owners;

namespace Millon.TecnicalTest.RealEstate.Data.Common.EntityConfigurations.Owners
{
    public class OwnerConfiguration : IEntityTypeConfiguration<Owner>
    {
        public void Configure(EntityTypeBuilder<Owner> builder)
        {

            builder.ToTable(nameof(Owner));

            builder.Property(x => x.Id)
                .IsRequired();

            builder.Property(p => p.Name)
                .HasMaxLength(OwnerModelConstants.Owner.MaxNameLength)
                .IsRequired();

            builder.Property(p => p.Address)
                .HasMaxLength(OwnerModelConstants.Owner.MaxAddressLength)
                .IsRequired();

            builder.Property(p => p.Photo)
                .HasMaxLength(OwnerModelConstants.Owner.MaxPhotoLength)
                .IsRequired();

            builder.Property(p => p.Birthday)
                .IsRequired();

            builder.Property(p => p.CreatedAtUtc)
                .IsRequired();

            builder.Property(p => p.UpdatedAtUtc);

            builder.Property(p => p.CreatedBy)
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(p => p.UpdatedBy)
                .HasMaxLength(500);

            builder.HasKey(p => p.Id);
        }
    }

}
