using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebApp.Models.Config
{
    public class KitapCFG : IEntityTypeConfiguration<Kitap>
    {
        public void Configure(EntityTypeBuilder<Kitap> builder)
        {
            builder.Property(x => x.KitapAdi).IsRequired().HasColumnType("varchar").HasMaxLength(200);
            builder.Property(x => x.Fiyat).HasColumnType("money");

        }
    }
}
