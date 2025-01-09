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
using Millon.TecnicalTest.RealEstate.Domain.Entities.Users;

namespace Millon.TecnicalTest.RealEstate.Data.Common.EntityConfigurations.Users
{
    public class UserConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {

            builder.ToTable(nameof(Usuario));

            builder.Property(x => x.Id)
                .HasMaxLength(UserModelConstants.Usuario.MaxIdLength)
                .IsRequired();

            builder.Property(p => p.Nombre)
                .HasMaxLength(UserModelConstants.Usuario.MaxNameLength)
                .IsRequired();

            builder.Property(p => p.Telefono)
                .HasMaxLength(UserModelConstants.Usuario.MaxPhoneLength)
                .IsRequired();

            builder.OwnsOne(p => p.Direccion)
                .Property(p => p.DireccionName)
                .HasMaxLength(UserModelConstants.Direccion.MaxNameLength)
                .IsRequired();
            builder.OwnsOne(p => p.Direccion)
                .Property(p => p.Municipioid)
                .HasMaxLength(LocationModelConstants.Municipio.MaxIdLength)
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
