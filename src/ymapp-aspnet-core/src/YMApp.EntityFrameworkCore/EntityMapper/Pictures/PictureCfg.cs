

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YMApp.ECommerce.Pictures;

namespace YMApp.EntityMapper.Pictures
{
    public class PictureCfg : IEntityTypeConfiguration<Picture>
    {
        public void Configure(EntityTypeBuilder<Picture> builder)
        {
            builder.ToTable("Pictures", YoYoAbpefCoreConsts.SchemaNames.CMS);
            builder.Property(a => a.Url).HasMaxLength(YoYoAbpefCoreConsts.EntityLengthNames.Length256);
            builder.Property(a => a.LinkUrl).HasMaxLength(YoYoAbpefCoreConsts.EntityLengthNames.Length256);
            builder.Property(a => a.Type).HasDefaultValue(0).IsRequired();
            builder.Property(a => a.Name).HasMaxLength(YoYoAbpefCoreConsts.EntityLengthNames.Length64);
            builder.Property(a => a.Sort).HasDefaultValue(0).IsRequired();
        }
    }
}


