using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebApp.Models.Config
{
    public class GunCFG : IEntityTypeConfiguration<Gun>
    {
        public void Configure(EntityTypeBuilder<Gun> builder)
        {
            builder.HasData(
                new Gun { GunID = 1, GunAdi = "Pazartesi" },
                new Gun { GunID = 2, GunAdi = "Salı" },
                new Gun { GunID = 3, GunAdi = "Çarşamba" },
                new Gun { GunID = 4, GunAdi = "Perşembe" },
                new Gun { GunID = 5, GunAdi = "Cuma" }
            );
        }
    }
}
