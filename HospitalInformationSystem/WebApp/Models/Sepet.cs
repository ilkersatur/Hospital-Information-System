namespace WebApp.Models
{
    public class Sepet
    {
        public int ID { get; set; }
        public int UyeID { get; set; }
        public int KitapID { get; set; }
        public int Adet { get; set; }

        public Kitap? Kitap { get; set; }
        public Uye? Uye { get; set; }
    }
}
