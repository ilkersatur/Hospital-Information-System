namespace WebApp.Models
{
    public class Doktor
    {
        public int DoktorID { get; set; }
        public string DoktorAdi { get; set; }

        public int PoliklinikID { get; set; }


        public ICollection<Poliklinik>? Poliklinikler { get; set; }
    }
}
