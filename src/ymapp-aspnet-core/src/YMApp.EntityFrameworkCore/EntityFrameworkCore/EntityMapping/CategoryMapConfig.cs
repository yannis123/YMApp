using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using YMApp.Categorys;

namespace YMApp.EntityFrameworkCore.EntityMapping
{
    public class CategoryMapConfig : EntityMappingConfiguration<Category>
    {
        public override void Map(EntityTypeBuilder<Category> b)
        {
            b.Property(p => p.Name).HasMaxLength(50).IsRequired();
            b.Property(p => p.ParentId).HasDefaultValue(0).IsRequired();
            b.Property(p => p.Grade).HasDefaultValue(0).IsRequired();
            b.Property(p => p.Sort).HasDefaultValue(0).IsRequired();
        }
    }
}
