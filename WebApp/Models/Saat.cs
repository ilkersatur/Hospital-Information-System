namespace WebApp.Models
{
    public class Saat
    {
        public int SaatID { get; set; }
        public string RandevuSaati { get; set; }
        public ICollection<RandevuTanimi> RandevuTanimlari { get; set; }
    }
}
