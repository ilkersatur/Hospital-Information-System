using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp.DAL;
using WebApp.Models;

namespace WebApp.Areas.AdminPanel.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("AdminPanel")]
    public class RandevuTanimlarController : Controller
    {
        private readonly HastaneDB _context;

        public RandevuTanimlarController(HastaneDB context)
        {
            _context = context;
        }

        // GET: AdminPanel/RandevuTanimlar
        public async Task<IActionResult> Index()
        {
            var hastaneDB = _context.RandevuTanimlari.Include(r => r.Gun).Include(r => r.Poliklinikler).Include(r => r.Saat);
            return View(await hastaneDB.ToListAsync());
        }

        // GET: AdminPanel/RandevuTanimlar/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.RandevuTanimlari == null)
            {
                return NotFound();
            }

            var randevuTanimi = await _context.RandevuTanimlari
                .Include(r => r.Gun)
                .Include(r => r.Poliklinikler)
                .Include(r => r.Saat)
                .FirstOrDefaultAsync(m => m.RandevuTanimiID == id);
            if (randevuTanimi == null)
            {
                return NotFound();
            }

            return View(randevuTanimi);
        }

        // GET: AdminPanel/RandevuTanimlar/Create
        public IActionResult Create()
        {
            ViewData["GunID"] = new SelectList(_context.Gunler, "GunID", "GunAdi");
            ViewData["PoliklinikID"] = new SelectList(_context.Poliklinikler, "PoliklinikID", "PoliklinikAdi");
            ViewData["SaatID"] = new SelectList(_context.Saatler, "SaatID", "RandevuSaati");
            return View();
        }

        // POST: AdminPanel/RandevuTanimlar/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RandevuTanimiID,PoliklinikID,GunID,SaatID,RandevuDurumu")] RandevuTanimi randevuTanimi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(randevuTanimi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GunID"] = new SelectList(_context.Gunler, "GunID", "GunID", randevuTanimi.GunID);
            ViewData["PoliklinikID"] = new SelectList(_context.Poliklinikler, "PoliklinikID", "PoliklinikID", randevuTanimi.PoliklinikID);
            ViewData["SaatID"] = new SelectList(_context.Saatler, "SaatID", "SaatID", randevuTanimi.SaatID);
            return View(randevuTanimi);
        }

        // GET: AdminPanel/RandevuTanimlar/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.RandevuTanimlari == null)
            {
                return NotFound();
            }

            var randevuTanimi = await _context.RandevuTanimlari.FindAsync(id);
            if (randevuTanimi == null)
            {
                return NotFound();
            }
            ViewData["GunID"] = new SelectList(_context.Gunler, "GunID", "GunID", randevuTanimi.GunID);
            ViewData["PoliklinikID"] = new SelectList(_context.Poliklinikler, "PoliklinikID", "PoliklinikID", randevuTanimi.PoliklinikID);
            ViewData["SaatID"] = new SelectList(_context.Saatler, "SaatID", "SaatID", randevuTanimi.SaatID);
            return View(randevuTanimi);
        }

        // POST: AdminPanel/RandevuTanimlar/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RandevuTanimiID,PoliklinikID,GunID,SaatID,RandevuDurumu")] RandevuTanimi randevuTanimi)
        {
            if (id != randevuTanimi.RandevuTanimiID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(randevuTanimi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RandevuTanimiExists(randevuTanimi.RandevuTanimiID))
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
            ViewData["GunID"] = new SelectList(_context.Gunler, "GunID", "GunID", randevuTanimi.GunID);
            ViewData["PoliklinikID"] = new SelectList(_context.Poliklinikler, "PoliklinikID", "PoliklinikID", randevuTanimi.PoliklinikID);
            ViewData["SaatID"] = new SelectList(_context.Saatler, "SaatID", "SaatID", randevuTanimi.SaatID);
            return View(randevuTanimi);
        }

        // GET: AdminPanel/RandevuTanimlar/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.RandevuTanimlari == null)
            {
                return NotFound();
            }

            var randevuTanimi = await _context.RandevuTanimlari
                .Include(r => r.Gun)
                .Include(r => r.Poliklinikler)
                .Include(r => r.Saat)
                .FirstOrDefaultAsync(m => m.RandevuTanimiID == id);
            if (randevuTanimi == null)
            {
                return NotFound();
            }

            return View(randevuTanimi);
        }

        // POST: AdminPanel/RandevuTanimlar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.RandevuTanimlari == null)
            {
                return Problem("Entity set 'HastaneDB.RandevuTanimlari'  is null.");
            }
            var randevuTanimi = await _context.RandevuTanimlari.FindAsync(id);
            if (randevuTanimi != null)
            {
                _context.RandevuTanimlari.Remove(randevuTanimi);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RandevuTanimiExists(int id)
        {
          return _context.RandevuTanimlari.Any(e => e.RandevuTanimiID == id);
        }
    }
}
