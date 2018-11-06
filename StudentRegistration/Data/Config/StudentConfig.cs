using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentRegistration.Models;

namespace StudentRegistration.Data.Config
{
    public class StudentConfig : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(c => c.StudentId);

            builder
                .Property(e => e.Name)
                .HasColumnType("varchar(250)")
                .HasMaxLength(250);

            builder
                .Property(e => e.Cpf)
                .HasColumnType("varchar(11)")
                .HasMaxLength(11);

            builder
                .HasMany(p => p.Phones)
                .WithOne(c => c.Student)
                .HasForeignKey(c => c.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .Ignore(e => e.ValidationResult);

            builder.ToTable("Students");
        }
    }
}