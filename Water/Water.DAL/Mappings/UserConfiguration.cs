using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Water.DAL.Models;

namespace Water.DAL.Mappings;

public class UserConfiguration: IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(user => user.Name)
            .HasMaxLength(256);

        builder
            .HasMany<Consumption>(user => user.Consumptions)
            .WithOne(consumption => consumption.User);
    }
}