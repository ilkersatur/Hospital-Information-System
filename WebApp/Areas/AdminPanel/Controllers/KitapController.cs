using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp.DAL;
using WebApp.Models;

namespace WebApp.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class KitapController : Controller
    {
        private readonly HastaneDB _context;

        public KitapController(HastaneDB context)
        {
            _context = context;
        }

        // GET: AdminPanel/Kitap
        public async Task<IActionResult> Index()
        {
            var kutuphaneDB = _context.Kitaplar.Include(k => k.Yazar);
            return View(await kutuphaneDB.ToListAsync());
        }

        // GET: AdminPanel/Kitap/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Kitaplar == null)
            {
                return NotFound();
            }

            var kitap = await _context.Kitaplar
                .Include(k => k.Yazar)
                .FirstOrDefaultAsync(m => m.KitapID == id);
            if (kitap == null)
            {
                return NotFound();
            }

            return View(kitap);
        }

        // GET: AdminPanel/Kitap/Create
        public IActionResult Create()
        {
            ViewData["YazarID"] = new SelectList(_context.Yazarlar, "YazarID", "YazarAdi");
            return View();
        }

        // POST: AdminPanel/Kitap/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("KitapID,KitapAdi,YazarID,Fiyat,ArkaKapakYazisi,KapakResmi,Onerilen,OduncVerildi,StokAdedi,OrtalamaPuan,EklendigiTarih")] Kitap kitap,IFormFile Kapak_Resmi)
        {
            if (ModelState.IsValid && kitap.YazarID!=0)
            {
                FileStream fs =new FileStream("wwwroot/Kapakresimleri/"+Kapak_Resmi.FileName,FileMode.Create);
                Kapak_Resmi.CopyTo(fs);
                fs.Close();
                kitap.KapakResmi = Kapak_Resmi.FileName;
                kitap.EklendigiTarih = DateTime.Now;
                _context.Add(kitap);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            if (kitap.YazarID == 0)
                ModelState.AddModelError("YazarID","Lütfen yazar seciniz...");
            ViewData["YazarID"] = new SelectList(_context.Yazarlar, "YazarID", "YazarAdi", kitap.YazarID);
            return View(kitap);
        }

        // GET: AdminPanel/Kitap/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Kitaplar == null)
            {
                return NotFound();
            }

            var kitap = await _context.Kitaplar.FindAsync(id);
            if (kitap == null)
            {
                return NotFound();
            }
            ViewData["YazarID"] = new SelectList(_context.Yazarlar, "YazarID", "YazarID", kitap.YazarID);
            return View(kitap);
        }

        // POST: AdminPanel/Kitap/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("KitapID,KitapAdi,YazarID,Fiyat,ArkaKapakYazisi,KapakResmi,Onerilen,OduncVerildi,StokAdedi,OrtalamaPuan,EklendigiTarih")] Kitap kitap)
        {
            if (id != kitap.KitapID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kitap);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KitapExists(kitap.KitapID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["YazarID"] = new SelectList(_context.Yazarlar, "YazarID", "YazarID", kitap.YazarID);
            return View(kitap);
        }

        // GET: AdminPanel/Kitap/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Kitaplar == null)
            {
                return NotFound();
            }

            var kitap = await _context.Kitaplar
                .Include(k => k.Yazar)
                .FirstOrDefaultAsync(m => m.KitapID == id);
            if (kitap == null)
            {
                return NotFound();
            }

            return View(kitap);
        }

        // POST: AdminPanel/Kitap/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Kitaplar == null)
            {
                return Problem("Entity set 'KutuphaneDB.Kitaplar'  is null.");
            }
            var kitap = await _context.Kitaplar.FindAsync(id);
            if (kitap != null)
            {
                _context.Kitaplar.Remove(kitap);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KitapExists(int id)
        {
          return _context.Kitaplar.Any(e => e.KitapID == id);
        }

        public IActionResult KategoriEkle(int? id)
        {
            //Daha once eklenmiş kategorileri gormek için
            ViewBag.Kategoriler = _context.Kitap_Kategori.Include("Kategori").Where(x => x.KitapID == id).ToList();
                        
            ViewBag.KitapID = new SelectList(_context.Kitaplar.Where(x => x.KitapID == id).ToList(), "KitapID", "KitapAdi");
            ViewBag.KategoriID = new SelectList(_context.Kategoriler,"KategoriID","KategoriAdi");

            return View();
        }
        [HttpPost]
        public IActionResult KategoriEkle(Kitap_Kategori kitapKategori)
        {
            _context.Kitap_Kategori.Add(kitapKategori);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
