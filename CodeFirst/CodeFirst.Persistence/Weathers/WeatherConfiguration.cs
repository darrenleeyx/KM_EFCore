using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodeFirst.Persistence.Weathers;

public class UsersConfigurations : IEntityTypeConfiguration<Weather>
{
    public void Configure(EntityTypeBuilder<Weather> builder)
    {
        builder
            .HasKey(x => x.Id);

        builder
            .Property(x => x.Id)
            .IsRequired();

        builder
            .Property(x => x.DateTime)
            .IsRequired();

        builder.Property(x => x.Description)
            .IsRequired();
    }
}
