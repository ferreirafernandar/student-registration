using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentRegistration.Models;

namespace StudentRegistration.Data.Mapping
{
    public class PhoneConfig : IEntityTypeConfiguration<Phone>
    {
        public void Configure(EntityTypeBuilder<Phone> builder)
        {
            builder.HasKey(c => c.PhoneId);

            builder
                .Property(e => e.Number)
                .HasColumnType("varchar(11)")
                .HasMaxLength(11);

            builder.ToTable("Phones");
        }
    }
}