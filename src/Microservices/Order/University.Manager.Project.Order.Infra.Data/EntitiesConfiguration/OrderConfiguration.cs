using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using University.Manager.Project.Order.Domain.Entities;

namespace University.Manager.Project.Order.Infra.Data.EntitiesConfiguration
{
    internal class OrderConfiguration : IEntityTypeConfiguration<OrderEntity>
    {
        public void Configure(EntityTypeBuilder<OrderEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.OrderType).IsRequired();
            builder.Property(x => x.Message).HasMaxLength(300).IsRequired();
            builder.Property(x => x.Title).HasMaxLength(20).IsRequired();
            builder.Property(x => x.UserId).IsRequired();
            builder.Property(x => x.Attachment).IsRequired();
            builder.Property(x => x.CreationData);
            builder.Property(x => x.UpdatedData);
        }
    }
}
