using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using University.Manager.Project.Student.Domain.Entities;

namespace University.Manager.Project.Student.Infra.Data.EntitiesConfiguration
{
    public class StudentConfiguration : IEntityTypeConfiguration<StudentEntity>
    {
        public void Configure(EntityTypeBuilder<StudentEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(200).IsRequired();
            builder.Property(x => x.SurName).HasMaxLength(200).IsRequired();
            builder.Property(x => x.RegisterCode).HasMaxLength(20).IsRequired();

            builder.Property(x => x.CourseId).IsRequired();
            builder.Property(x => x.CreationData).IsRequired();
            builder.Property(x => x.UpdatedData).IsRequired();
            builder.Property(x => x.Email).HasMaxLength(200).IsRequired();
            builder.Property(x => x.Passowrd).HasMaxLength(400).IsRequired();

        }
    }
}
