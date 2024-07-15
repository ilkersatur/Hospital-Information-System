using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Security.Cryptography.X509Certificates;
using WebApp.DAL;
using WebApp.Models;

namespace WebApp.Areas.UyePanel.Controllers
{
    [Authorize(Roles = "Uye")]
    [Area("UyePanel")]
    public class UyeController : Controller
    {
        UserManager<Uye> _userManager;
        HastaneDB _db;
        public UyeController(UserManager<Uye> userManager, HastaneDB db)
        {
            _userManager = userManager;
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult YorumEkle(int kitapID, string mesaj)
        {
            Yorum yorum = new Yorum();
            yorum.Mesaj = mesaj;
            yorum.KitapID = kitapID;
            yorum.UyeID = GetUserID();
            yorum.YorumTarih = DateTime.Now;

            _db.Yorumlar.Add(yorum);
            _db.SaveChanges();
            return Redirect("~/Kutuphane/Detay/" + kitapID);
            //return Content("UyeID="+ userID + " "+ kitapID + " " + mesaj);
        }

        public IActionResult SepeteEkle(int id)
        {

            //Oncelikli olarak ilgili uyenin, secgi kitap var mı?
            //Varsa INSERT
            //Yoksa UPDATE
            int uyeID = GetUserID();
            var liste = _db.Sepetler.Where(x => x.UyeID == uyeID && x.KitapID == id);
            Sepet sepet = new Sepet();
            sepet.UyeID = uyeID;
            sepet.KitapID = id;
            if (liste.Count() == 0)
            {
                sepet.Adet = 1;
                _db.Sepetler.Add(sepet);
            }
            else
            {
                Sepet spt = liste.SingleOrDefault<Sepet>();
                _db.Entry(spt).State = EntityState.Modified;
                spt.Adet += 1;
            }
            _db.SaveChanges();
            return Redirect("~/Kutuphane/Index");
        }

        [HttpPost]
        public IActionResult SatinAl(IFormCollection frm)
        {
            bool hepsiTamam = true;
            if (frm != null)
            {
                foreach (var item in frm.Keys)
                {
                    string[] veri = item.Split("_");
                    if (veri[0] == "Adet")
                    {
                        int kitapID = int.Parse(veri[1].ToString());
                        //stokta var mı?
                        Kitap kitap = _db.Kitaplar.Where(x => x.KitapID == kitapID).SingleOrDefault();

                        if (kitap.StokAdedi < int.Parse(frm[item]))
                        {
                            TempData["STOK"] = "Stok Yetersiz..." + kitap.KitapAdi;
                            hepsiTamam = false;
                        }
                        
                    }
                }
            }

            if (hepsiTamam)
            {
                foreach (var item in frm.Keys)
                {
                    string[] veri = item.Split("_");
                    if (veri[0] == "Adet")
                    {
                        int kitapID = int.Parse(veri[1].ToString());
                        
                        Kitap kitap = _db.Kitaplar.Where(x => x.KitapID == kitapID).SingleOrDefault();

                        kitap.StokAdedi -= int.Parse(frm[item]);
                        _db.Entry<Kitap>(kitap).State = EntityState.Modified;

                        //sepetten sil...
                        _db.Sepetler.Remove(_db.Sepetler.Where(x => x.KitapID == kitapID && x.UyeID == GetUserID()).SingleOrDefault());

                        _db.SaveChanges();
                       
                    }
                }
                return Redirect("~/Kutuphane");
            }

                    return RedirectToAction("SepetGoster");
        }


            public IActionResult SepetGoster()
        {
            int uyeID = GetUserID();
            var sepettekiKitaplar = _db.Sepetler.Include("Kitap").Where(x=>x.UyeID ==uyeID);

            return View(sepettekiKitaplar.ToList());

        }

        private int GetUserID()
        {
            return int.Parse(_userManager.GetUserId(User));
        }

    }
}
