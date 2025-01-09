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
using Millon.TecnicalTest.RealEstate.Domain.Entities.Location;

namespace Millon.TecnicalTest.RealEstate.Data.Common.EntityConfigurations.Location
{
    public class MunicipioConfiguration : IEntityTypeConfiguration<Municipio>
    {
        public void Configure(EntityTypeBuilder<Municipio> builder)
        {
            builder.ToTable(nameof(Municipio));

            builder.Property(x => x.Id)
                .HasMaxLength(LocationModelConstants.Municipio.MaxIdLength)
                .IsRequired();

            builder.Property(p => p.Name)
                .HasMaxLength(ModelConstants.Common.MaxNameLength)
                .IsRequired();

            builder.Property(p => p.DepartamentoId)
                .HasMaxLength(LocationModelConstants.Departamento.MaxIdLength)
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
