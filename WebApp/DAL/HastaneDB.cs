using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApp.Models;
using WebApp.Models.Config;
using WebApplication1.Models;

namespace WebApp.DAL
{
    //public class KutuphaneDB:IdentityDbContext
    public class HastaneDB:IdentityDbContext<Uye,Rol,int>
    {
        public HastaneDB(DbContextOptions<HastaneDB> options):base(options)
        {
                
        }

        public DbSet<Kitap> Kitaplar { get; set; }
        public DbSet<Kategori> Kategoriler { get; set; }
        public DbSet<Yazar> Yazarlar { get; set; }
        public DbSet<Kitap_Kategori> Kitap_Kategori { get; set; }
        public DbSet<OduncVerme> OduncVerme { get; set; }
        public DbSet<Puan> Puanlar { get; set; }
        public DbSet<Sepet> Sepetler { get; set; }
        public DbSet<Yorum> Yorumlar { get; set; }

        public DbSet<Uye> Uyeler { get; set; }
        public DbSet<Rol> Roller { get; set; }

        public DbSet<Poliklinik> Poliklinikler { get; set; }
        public DbSet<Gun> Gunler { get; set; }
        public DbSet<Saat> Saatler { get; set; }
        public DbSet<RandevuTanimi> RandevuTanimlari { get; set; }
        public DbSet<Randevu> Randevular { get; set; }
        public DbSet<Randevu_VM> randevu_VMler { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.ApplyConfiguration<Yazar>(new YazarCFG());
            //builder.ApplyConfiguration<Kitap>(new KitapCFG());
            //builder.ApplyConfiguration<Rol>(new RolCFG());

            builder.ApplyConfiguration<Gun>(new GunCFG());
            builder.ApplyConfiguration<Saat>(new SaatCFG());
            builder.ApplyConfiguration<Poliklinik>(new PoliklinikCFG());
            builder.ApplyConfiguration<Rol>(new RolCFG());

            base.OnModelCreating(builder);
        }
    }
}
