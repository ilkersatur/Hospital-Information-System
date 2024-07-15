using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebApp.Models.Config
{
    public class SaatCFG : IEntityTypeConfiguration<Saat>
    {
        public void Configure(EntityTypeBuilder<Saat> builder)
        {
            builder.HasData(
                new Saat { SaatID = 1, RandevuSaati = "10" },
                new Saat { SaatID = 2, RandevuSaati = "11" },
                new Saat { SaatID = 3, RandevuSaati = "12" },
                new Saat { SaatID = 4, RandevuSaati = "13" },
                new Saat { SaatID = 5, RandevuSaati = "14" },
                new Saat { SaatID = 6, RandevuSaati = "15" },
                new Saat { SaatID = 7, RandevuSaati = "16" }
                );
        }
    }
}
