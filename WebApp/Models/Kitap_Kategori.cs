using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class Kitap_Kategori
    {
        [Key]
        public int KKID { get; set; }

        public int KitapID { get; set; }
        public int KategoriID { get; set; }

        public ICollection<Kitap_Kategori>? Kategoriler { get; set; }
        public ICollection<OduncVerme>? Oduncler { get; set; }
        public ICollection<Puan>? Puanlar { get; set; }
        public ICollection<Sepet>? Sepetler { get; set; }
        public ICollection<Yorum>? Yorumlar { get; set; }

        public Kitap? Kitap { get; set; }
        public Kategori? Kategori { get; set; }
    }
}
