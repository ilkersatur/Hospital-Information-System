namespace WebApp.Models
{
    public class Kategori
    {
        public int KategoriID { get; set; }
        public string KategoriAdi { get; set; }

        public ICollection<Kitap_Kategori>? Kitaplar { get; set; }
    }
}
