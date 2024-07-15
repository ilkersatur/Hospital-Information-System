namespace WebApp.Models
{
    public class Gun
    {
        public int GunID { get; set; }
        public string GunAdi { get; set; }
        public ICollection<RandevuTanimi> RandevuTanimlari { get; set; }
    }
}
