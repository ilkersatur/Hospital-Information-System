using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp.DAL;
using WebApp.Models;
using WebApplication1.Models;

namespace WebApp.Areas.UyePanel.Controllers
{
    [Authorize(Roles = "Uye")]
    [Area("UyePanel")]
    public class RandevularController : Controller
    {
        private readonly HastaneDB _context;
        UserManager<Uye> _userManager;
        public RandevularController(HastaneDB context, UserManager<Uye> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: UyePanel/Randevular
        public async Task<IActionResult> Index()
        {
            var uyeID = GetUserID();

            var hastaneDB = _context.Randevular.Include(r => r.RandevuTanimi).Include(r => r.Uye).Where(x=>x.UyeID==uyeID );
            return View(await hastaneDB.ToListAsync());
        }

        // GET: UyePanel/Randevular/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Randevular == null)
            {
                return NotFound();
            }

            var randevu = await _context.Randevular
                .Include(r => r.RandevuTanimi)
                .Include(r => r.Uye)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (randevu == null)
            {
                return NotFound();
            }

            return View(randevu);
        }

        private int GetUserID()
        {
            return int.Parse(_userManager.GetUserId(User));
        }
        // GET: UyePanel/Randevular/Create
        public IActionResult Create(int? id = 1)
        {
            DateTime bugun = DateTime.Now;

            int gunIndis = ((int)bugun.DayOfWeek + 1) % 5;
            ViewBag.Gun = _context.Gunler.Find(gunIndis).GunAdi;

            var liste = _context.RandevuTanimlari.Include("Saat").Where(x => x.PoliklinikID == id && x.GunID == gunIndis && x.RandevuDurumu != true);

            List<Randevu_VM> randevular = new List<Randevu_VM>();
            foreach (var item in liste)
            {
                randevular.Add(new Randevu_VM() { ID = item.RandevuTanimiID, GunID = item.GunID, Saat = item.Saat.RandevuSaati });
            }

            ViewData["RandevuTanimiID"] = new SelectList(randevular.ToList(), "ID", "Saat");

            ViewBag.Poliklinikler = new SelectList(_context.Poliklinikler.ToList(), "PoliklinikID", "PoliklinikAdi",id.Value.ToString());
            // ViewData["UyeID"] = new SelectList(_context.Uyeler, "Id", "Id");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int randevuTanimiID)
        {
            _context.Randevular.Add(new Randevu
            {
                RandevuTanimiID = randevuTanimiID,
                RandevuTarihi = DateTime.Now.AddDays(1),
                UyeID = GetUserID()
            });

            _context.SaveChanges();
            var randevuTanimi = _context.RandevuTanimlari.Find(randevuTanimiID);
            randevuTanimi.RandevuDurumu = true;
            _context.Entry<RandevuTanimi>(randevuTanimi).State = EntityState.Modified;

            _context.SaveChanges();
            //return Content("ID=" + randevuTanimiID);
            return RedirectToAction("Index");
        }

        // GET: UyePanel/Randevular/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Randevular == null)
            {
                return NotFound();
            }

            var randevu = await _context.Randevular.FindAsync(id);
            if (randevu == null)
            {
                return NotFound();
            }
            ViewData["RandevuTanimiID"] = new SelectList(_context.RandevuTanimlari, "RandevuTanimiID", "RandevuTanimiID", randevu.RandevuTanimiID);
            ViewData["UyeID"] = new SelectList(_context.Uyeler, "Id", "Id", randevu.UyeID);
            return View(randevu);
        }

        // POST: UyePanel/Randevular/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,UyeID,RandevuTanimiID,RandevuTarihi,UyeGeldiMi")] Randevu randevu)
        {
            if (id != randevu.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(randevu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RandevuExists(randevu.ID))
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
            ViewData["RandevuTanimiID"] = new SelectList(_context.RandevuTanimlari, "RandevuTanimiID", "RandevuTanimiID", randevu.RandevuTanimiID);
            ViewData["UyeID"] = new SelectList(_context.Uyeler, "Id", "Id", randevu.UyeID);
            return View(randevu);
        }

        // GET: UyePanel/Randevular/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Randevular == null)
            {
                return NotFound();
            }

            var randevu = await _context.Randevular
                .Include(r => r.RandevuTanimi)
                .Include(r => r.Uye)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (randevu == null)
            {
                return NotFound();
            }

            return View(randevu);
        }

        // POST: UyePanel/Randevular/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Randevular == null)
            {
                return Problem("Entity set 'HastaneDB.Randevular'  is null.");
            }
            var randevu = await _context.Randevular.FindAsync(id);
            if (randevu != null)
            {
                _context.Randevular.Remove(randevu);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RandevuExists(int id)
        {
          return _context.Randevular.Any(e => e.ID == id);
        }
    }
}
