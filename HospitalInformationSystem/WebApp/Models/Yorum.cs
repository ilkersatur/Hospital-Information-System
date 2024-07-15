using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models
{
    public class Yorum
    {
        public int YorumID { get; set; }
        public int UyeID { get; set; }

        //[ForeignKey("Yorumlayan")]
        //public int? YorumlayanID { get; set; }
        //[ForeignKey("Yorumlanan")]
        //public int? YorumlananID { get; set; }

        public int KitapID { get; set; }
        public string Mesaj { get; set; }
        public DateTime YorumTarih { get; set; }

        public Kitap? Kitap { get; set; }

        public Uye? Uye  { get; set; }
        //public Uye? Yorumlayan { get; set; }
        //public Uye? Yorumlanan { get; set; }
    }
}
