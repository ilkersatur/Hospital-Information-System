using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebApp.Models.Config
{
    public class PoliklinikCFG : IEntityTypeConfiguration<Poliklinik>
    {
        public void Configure(EntityTypeBuilder<Poliklinik> builder)
        {
            builder.HasData(
                new Poliklinik { PoliklinikID = 1, PoliklinikAdi = "Kulak Burun Boğaz", Resim = "resim1.jpg" },
                new Poliklinik { PoliklinikID = 2, PoliklinikAdi = "Genel Cerrahi", Resim = "resim2.jpg" },
                new Poliklinik { PoliklinikID = 3, PoliklinikAdi = "Göz", Resim = "resim3.jpg" }
                );
        }
    }
}
