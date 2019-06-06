

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YMApp.ECommerce.Articles;

namespace YMApp.EntityMapper.Articles
{
    public class ArticleMapConfig : EntityMappingConfiguration<Article>
    {
        public override void Map(EntityTypeBuilder<Article> b)
        {
            b.Property(a => a.CategoryId).HasDefaultValue(0).IsRequired();
            b.Property(a => a.Category).HasMaxLength(YoYoAbpefCoreConsts.EntityLengthNames.Length64);
            b.Property(a => a.Title).HasMaxLength(200).IsRequired().HasDefaultValue("");
            b.Property(a => a.Author).HasMaxLength(20).HasDefaultValue("");
            b.Property(a => a.TextContent).HasColumnType("ntext");
            b.Property(a => a.Source).HasMaxLength(50);
            b.Property(a => a.State).HasDefaultValue(0).IsRequired();
            b.HasOne(a => a.Category);
        }
    }
}


