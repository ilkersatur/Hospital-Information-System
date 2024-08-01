namespace WebApp.Models
{
    public class Poliklinik
    {
        public int PoliklinikID { get; set; }
        public string PoliklinikAdi { get; set; }
        public string Resim { get; set; }

        public ICollection<RandevuTanimi>? RandevularTanimlari { get; set; }
    }
}
