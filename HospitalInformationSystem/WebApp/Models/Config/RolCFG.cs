using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebApp.Models.Config
{
    public class RolCFG : IEntityTypeConfiguration<Rol>
    {
        public void Configure(EntityTypeBuilder<Rol> builder)
        {
            builder.HasData(new Rol { Id = 1, Name = "Admin", NormalizedName = "ADMIN" });
            builder.HasData(new Rol { Id = 2, Name = "Uye", NormalizedName = "UYE" });
        }
    }
}
