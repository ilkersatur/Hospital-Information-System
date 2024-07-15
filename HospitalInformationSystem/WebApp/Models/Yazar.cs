namespace WebApp.Models
{
    public class Yazar
    {
        public int YazarID { get; set; }
        public string YazarAdi { get; set; }
        public string Biyografi { get; set; }

        public ICollection<Kitap>? Kitaplar { get; set; }
    }
}
