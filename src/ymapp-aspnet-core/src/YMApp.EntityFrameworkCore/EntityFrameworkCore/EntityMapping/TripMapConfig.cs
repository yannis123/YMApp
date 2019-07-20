using System;
using Microsoft.EntityFrameworkCore;
using YMApp.ECommerce.Trips;

namespace YMApp.EntityFrameworkCore.EntityMapping
{
    public class TripMapConfig : EntityMappingConfiguration<Trip>
    {
        public override void Map(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Trip> b)
        {
            b.Property(p => p.Name).HasMaxLength(200).IsRequired();
            b.Property(p => p.Content).HasColumnType("ntext");
            b.Property(p => p.Describe).HasMaxLength(500);
            b.Property(p => p.PictureUrl).HasMaxLength(200);
            b.Property(p => p.State).HasDefaultValue(0).IsRequired();
            b.HasOne(p => p.Category);
        }
    }
}
