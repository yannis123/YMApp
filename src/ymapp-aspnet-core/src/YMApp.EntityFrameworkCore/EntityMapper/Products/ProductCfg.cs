

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YMApp.ECommerce.Products;

namespace YMApp.EntityMapper.Products
{
    public class ProductCfg : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {

            builder.ToTable("Products", YoYoAbpefCoreConsts.SchemaNames.CMS);
            builder.Property(a => a.CategoryId).HasDefaultValue(0).IsRequired();
            builder.Property(a => a.ProductCode).HasMaxLength(YoYoAbpefCoreConsts.EntityLengthNames.Length64);
            builder.Property(a => a.ProductName).HasMaxLength(YoYoAbpefCoreConsts.EntityLengthNames.Length64);
            builder.Property(a => a.Describe).HasColumnType("ntext");
            builder.Property(a => a.State).HasDefaultValue(0).IsRequired();
            builder.HasOne(a => a.Category);
            builder.HasMany(a => a.Pictures);

        }
    }
}


