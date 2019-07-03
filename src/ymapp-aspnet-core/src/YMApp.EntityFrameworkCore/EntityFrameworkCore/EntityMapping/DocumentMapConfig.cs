

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YMApp.DocManage.Documents;
using YMApp.ECommerce.Articles;

namespace YMApp.EntityFrameworkCore.EntityMapping
{
    public class DocumentMapConfig : EntityMappingConfiguration<Document>
    {
        public override void Map(EntityTypeBuilder<Document> b)
        {
            b.Property(a => a.CategoryId).HasDefaultValue(0).IsRequired();
            b.Property(a => a.Name).HasMaxLength(50).IsRequired().HasDefaultValue("");
            b.Property(a => a.OriName).HasMaxLength(50).IsRequired().HasDefaultValue("");
            b.Property(a => a.Describe).HasMaxLength(200).HasDefaultValue("");
            b.Property(a => a.FilePath).HasMaxLength(200).IsRequired().HasDefaultValue("");
            b.Property(a => a.FileSize).HasMaxLength(50);
            b.Property(a => a.State).HasDefaultValue(0).IsRequired();
            b.HasOne(a => a.Category);
        }
    }
}


