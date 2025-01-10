// ****************************************************************
//  Assembly         : Millon.TecnicalTest.RealEstate.Data
//  Author           :  Carlos Fernando Malagón Cano
//  Created          : 11-10-2024
//
//  Last Modified By : Carlos Fernando Malagón Cano
//  Last Modified On : 11-10-2024
//  ****************************************************************
//  <copyright file="ApplicationDbContext.cs"
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
    public class PropertyImageConfiguration : IEntityTypeConfiguration<PropertyImage>
    {
        public void Configure(EntityTypeBuilder<PropertyImage> builder)
        {

            builder.ToTable(nameof(PropertyImage));

            builder.Property(x => x.Id)
                .IsRequired();

            builder.Property(p => p.File)
                .HasMaxLength(PropertyModelConstants.Property.MaxNameLength)
                .IsRequired();

            builder.Property(p => p.Enabled)
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
            builder.HasOne(e => e.Property)
                .WithMany(e => e.Images)
                .HasForeignKey(e => e.IdProperty)
                .IsRequired();
        }
    }

}
