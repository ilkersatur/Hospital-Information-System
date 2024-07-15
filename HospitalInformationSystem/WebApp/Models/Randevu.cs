namespace WebApp.Models
{
    public class Randevu
    {
        public int ID { get; set; }
        
        public int UyeID { get; set; }

        public int RandevuTanimiID { get; set; }

        public DateTime RandevuTarihi { get; set; }

        public bool UyeGeldiMi { get; set; }


        public Uye? Uye { get; set; }

        public RandevuTanimi? RandevuTanimi { get; set; }
    }
}