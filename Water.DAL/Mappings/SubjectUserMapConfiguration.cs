using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Water.DAL.Models;

namespace Water.DAL.Mappings;

public class SubjectUserMapConfiguration: IEntityTypeConfiguration<SubjectUserMap>
{
    public void Configure(EntityTypeBuilder<SubjectUserMap> builder)
    {
        builder.HasKey(map => map.Subject);
        
        builder.Property(map => map.Subject)
            .HasMaxLength(256);
    }
}