using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models
{
    public class Uye:IdentityUser<int>
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Adres { get; set; }

        public ICollection<OduncVerme>? Oduncler { get; set; }
        public ICollection<Puan>? Puanlar { get; set; }
        public ICollection<Sepet>? Sepetler { get; set; }

        public ICollection<Yorum>? Yorumlar { get; set; }

        public ICollection<Randevu>? Randevular { get; set; }

    }
}