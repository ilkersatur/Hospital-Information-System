namespace WebApp.Models
{
    public class RandevuTanimi
    {
        public int RandevuTanimiID { get; set; }
        public int PoliklinikID { get; set; }
        public int GunID { get; set; }
        public int SaatID { get; set; }
        public bool RandevuDurumu { get; set; }

        public Gun? Gun { get; set; }
        public Saat? Saat { get; set; }

        public ICollection<RandevuTanimi>? RandevuTanimlari { get; set; }
        public Poliklinik? Poliklinikler { get; set; }
    }
}
