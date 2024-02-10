using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Water.DAL.Models;

namespace Water.DAL.Mappings;

public class ConsumptionConfiguration: IEntityTypeConfiguration<Consumption>
{
    public void Configure(EntityTypeBuilder<Consumption> builder)
    {
        builder
            .HasOne<User>(consumption => consumption.User)
            .WithMany(user => user.Consumptions);
    }
}