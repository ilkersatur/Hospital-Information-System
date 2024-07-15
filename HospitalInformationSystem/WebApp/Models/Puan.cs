using System.Transactions;

namespace WebApp.Models
{
    public class Puan
    {
        public int PuanID { get; set; }
        public int UyeID  { get; set; }
        public int KitapID { get; set; }
        public int Puanlama { get; set; }
        public DateTime Tarih { get; set; }

        public Kitap? Kitap { get; set; }
        public Uye? Uye { get; set; }
    }
}
