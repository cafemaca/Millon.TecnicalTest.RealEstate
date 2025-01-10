// ****************************************************************
//  Assembly         : Millon.TecnicalTest.RealEstate.Data
//  Author           :  Carlos Fernando Malagón Cano
//  Created          : 01-10-2025
//
//  Last Modified By : Carlos Fernando Malagón Cano
//  Last Modified On : 01-10-2025
//  ****************************************************************
//  <copyright file="PropertyConfiguration.cs"
//      company="Cafemaca - CAFEMACA Colombia">
//      Cafemaca - CAFEMACA Colombia
//  </copyright>
//


using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Millon.TecnicalTest.RealEstate.Domain.Common.ModelConstants;
using Millon.TecnicalTest.RealEstate.Domain.Entities.Properties;

namespace Millon.TecnicalTest.RealEstate.Data.Common.EntityConfigurations.Properties
{
    public class PropertyConfiguration : IEntityTypeConfiguration<Property>
    {
        public void Configure(EntityTypeBuilder<Property> builder)
        {

            builder.ToTable(nameof(Property));

            builder.Property(x => x.Id)
                .IsRequired();

            builder.Property(p => p.Name)
                .HasMaxLength(PropertyModelConstants.Property.MaxNameLength)
                .IsRequired();

            builder.Property(p => p.Address)
                .HasMaxLength(PropertyModelConstants.Property.MaxAddressLength)
                .IsRequired();

            builder.Property(p => p.Price)
                .IsRequired();

            builder.Property(p => p.CodeInternal)
                .HasMaxLength(PropertyModelConstants.Property.MaxCodeInternalLength)
                .IsRequired();

            builder.Property(p => p.Year)
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
            builder.HasOne(e => e.Owner)
                .WithMany(e => e.Properties)
                .HasForeignKey(e => e.IdOwner)
                .IsRequired();
        }
    }
}
