using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using University.Manager.Project.Course.Domain.Entities;

namespace University.Manager.Project.Course.Infra.Data.EntitiesConfiguration
{
    public class CourseConfiguration : IEntityTypeConfiguration<CourseEntity>
    {
        public void Configure(EntityTypeBuilder<CourseEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(200).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(200).IsRequired();
            builder.Property(x => x.Workload);
            builder.HasOne(x => x.CourseCategory).WithMany(x => x.Courses);
            builder.Property(x => x.TotalValue).HasPrecision(10, 2);
        }
    }
}
