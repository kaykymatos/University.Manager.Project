using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Manager.Project.Financial.Domain.Entities;

namespace University.Manager.Project.Financial.Infra.Data.EntitiesConfiguration
{
    public class CourseInstallmentConfiguration : IEntityTypeConfiguration<CourseInstallments>
    {
        public void Configure(EntityTypeBuilder<CourseInstallments> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.StudentId).IsRequired();
            builder.Property(x => x.InstallmentPrice).IsRequired().HasPrecision(10, 2);
            builder.Property(x => x.InstallmentsNumber).IsRequired();
            builder.Property(x => x.CreationData).IsRequired();
            builder.Property(x => x.UpdatedData).IsRequired();
        }
    }
}
