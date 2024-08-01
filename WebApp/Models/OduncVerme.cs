namespace WebApp.Models
{
    public class OduncVerme
    {
        public int OduncVermeID { get; set; }
        public int UyeID { get; set; }
        public int KitapID { get; set; }
        public DateTime VerilisTarihi { get; set; }
        public DateTime VarsayilanTeslimTarihi { get; set; } //10 gün ekle
        public DateTime TeslimTarihi { get; set; }

        public Kitap? Kitap { get; set; }
        public Uye? Uye { get; set; }
    }
}
