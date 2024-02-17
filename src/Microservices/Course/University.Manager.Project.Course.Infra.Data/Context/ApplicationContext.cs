using Microsoft.EntityFrameworkCore;
using University.Manager.Project.Course.Domain.Entities;

namespace University.Manager.Project.Course.Infra.Data.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
             : base(options)
        {

        }
        public DbSet<CourseCategory> CourseCategories { get; set; }
        public DbSet<CourseEntity> Courses { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
        }
    }
}
