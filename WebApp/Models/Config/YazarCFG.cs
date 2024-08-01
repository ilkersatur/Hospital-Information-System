using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebApp.Models.Config
{
    public class YazarCFG : IEntityTypeConfiguration<Yazar>
    {
        public void Configure(EntityTypeBuilder<Yazar> builder)
        {
            builder.HasData(new Yazar { YazarID=1, YazarAdi="Dan Brown", Biyografi="" });
            builder.HasData(new Yazar { YazarID=2, YazarAdi="Jack London", Biyografi="" });
            builder.HasData(new Yazar { YazarID=3, YazarAdi="F.Dostoyevski", Biyografi="" });
            builder.HasData(new Yazar { YazarID=4, YazarAdi="Charles Dickens", Biyografi="" });
            builder.HasData(new Yazar { YazarID=5, YazarAdi="Halide Edip Adıvar", Biyografi="" });
            builder.HasData(new Yazar { YazarID=6, YazarAdi="Tolstoy", Biyografi="" });
            builder.HasData(new Yazar { YazarID=7, YazarAdi="John Steinbeck", Biyografi="" });
            builder.HasData(new Yazar { YazarID=8, YazarAdi="Adam Fawer", Biyografi="" });
            builder.HasData(new Yazar { YazarID=9, YazarAdi="John Verdon", Biyografi="" });
        }
    }
}
