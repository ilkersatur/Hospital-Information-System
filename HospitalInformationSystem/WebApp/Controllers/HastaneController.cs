using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.DAL;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HastaneController : Controller
    {
        HastaneDB _db;
        public HastaneController(HastaneDB db)
        {
            _db = db;
            _db.Database.EnsureCreated();
        }

        public IActionResult Index()
        {
            var kitaplar = _db.Kitaplar;
                   
            return View(kitaplar.ToList());
        }

        public IActionResult Detay(int id)
        {

            var kitap = _db.Kitaplar.Include("Yazar").ToList().Find(x=>x.KitapID==id);
            //var kitap = _db.Kitaplar.Find(id);

            ViewBag.kategoriler = _db.Kitap_Kategori.Include("Kategori").Where(x => x.KitapID == id);

            ViewBag.yorumlar = _db.Yorumlar.Include("Uye").Where(x=>x.KitapID==id).OrderByDescending(x=>x.YorumTarih).ToList();

            return View(kitap);
        }

        public IActionResult SepeteEkle()
        {
            return Content("sepete eklenmiştir...");
        }
    }
}
