using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Millon.TecnicalTest.RealEstate.Domain.Common.ModelConstants;
using Millon.TecnicalTest.RealEstate.Domain.Entities.Properties;

namespace Millon.TecnicalTest.RealEstate.Data.Common.EntityConfigurations.Properties
{
    public class PropertyTraceConfiguration : IEntityTypeConfiguration<PropertyTrace>
    {
        public void Configure(EntityTypeBuilder<PropertyTrace> builder)
        {

            builder.ToTable(nameof(PropertyTrace));

            builder.Property(x => x.Id)
                .IsRequired();

            builder.Property(p => p.DateSale)
                .IsRequired();

            builder.Property(p => p.Name)
                .HasMaxLength(PropertyModelConstants.Property.MaxNameLength)
                .IsRequired();

            builder.Property(p => p.Value)
                .IsRequired();

            builder.Property(p => p.Tax)
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
                .WithMany(e => e.Traces)
                .HasForeignKey(e => e.IdProperty)
                .IsRequired();
        }
    }
}
