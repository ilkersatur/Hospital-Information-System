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
    public class RandevlarController : Controller
    {
        private readonly HastaneDB _context;

        public RandevlarController(HastaneDB context)
        {
            _context = context;
        }

        // GET: AdminPanel/Randevlar
        public async Task<IActionResult> Index()
        {
            var hastaneDB = _context.Randevular.Include(r => r.RandevuTanimi).Include(r => r.Uye);
            return View(await hastaneDB.ToListAsync());
        }

        // GET: AdminPanel/Randevlar/Details/5
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

        // GET: AdminPanel/Randevlar/Create
        public IActionResult Create()
        {
            ViewData["RandevuTanimiID"] = new SelectList(_context.RandevuTanimlari, "RandevuTanimiID", "RandevuTanimiID");
            ViewData["UyeID"] = new SelectList(_context.Uyeler, "Id", "Id");
            return View();
        }

        // POST: AdminPanel/Randevlar/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,UyeID,RandevuTanimiID,RandevuTarihi,UyeGeldiMi")] Randevu randevu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(randevu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RandevuTanimiID"] = new SelectList(_context.RandevuTanimlari, "RandevuTanimiID", "RandevuTanimiID", randevu.RandevuTanimiID);
            ViewData["UyeID"] = new SelectList(_context.Uyeler, "Id", "Id", randevu.UyeID);
            return View(randevu);
        }

        // GET: AdminPanel/Randevlar/Edit/5
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

        // POST: AdminPanel/Randevlar/Edit/5
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

        // GET: AdminPanel/Randevlar/Delete/5
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

        // POST: AdminPanel/Randevlar/Delete/5
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
