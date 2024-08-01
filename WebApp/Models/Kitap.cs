namespace WebApp.Models
{
    public class Kitap
    {
        public  int KitapID { get; set; }
        public string KitapAdi { get; set; }
        public int YazarID { get; set; }
        public decimal Fiyat { get; set; }
        public string ArkaKapakYazisi { get; set; }
        public string KapakResmi { get; set; }
        public bool Onerilen { get; set; }
        public bool OduncVerildi { get; set; }
        public int StokAdedi { get; set; }
        public double OrtalamaPuan { get; set; }
        public DateTime EklendigiTarih { get; set; }

        public ICollection<Kitap_Kategori>? Kategoriler { get; set; }
        public ICollection<OduncVerme>? Oduncler { get; set; }

        public ICollection<Puan>? Puanlar { get; set; }
        public ICollection<Sepet>? Sepetler { get; set; }
        public ICollection<Yorum>? Yorumlar { get; set; }

        public Yazar? Yazar { get; set; }


    }
}
