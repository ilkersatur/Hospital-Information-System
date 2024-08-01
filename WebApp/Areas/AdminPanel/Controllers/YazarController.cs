using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp.DAL;
using WebApp.Models;

namespace WebApp.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class YazarController : Controller
    {
        private readonly HastaneDB _context;

        public YazarController(HastaneDB context)
        {
            _context = context;
        }

        // GET: AdminPanel/Yazar
        public async Task<IActionResult> Index()
        {
              return View(await _context.Yazarlar.ToListAsync());
        }

        // GET: AdminPanel/Yazar/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Yazarlar == null)
            {
                return NotFound();
            }

            var yazar = await _context.Yazarlar
                .FirstOrDefaultAsync(m => m.YazarID == id);
            if (yazar == null)
            {
                return NotFound();
            }

            return View(yazar);
        }

        // GET: AdminPanel/Yazar/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AdminPanel/Yazar/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("YazarID,YazarAdi,Biyografi")] Yazar yazar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(yazar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(yazar);
        }

        // GET: AdminPanel/Yazar/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Yazarlar == null)
            {
                return NotFound();
            }

            var yazar = await _context.Yazarlar.FindAsync(id);
            if (yazar == null)
            {
                return NotFound();
            }
            return View(yazar);
        }

        // POST: AdminPanel/Yazar/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("YazarID,YazarAdi,Biyografi")] Yazar yazar)
        {
            if (id != yazar.YazarID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(yazar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!YazarExists(yazar.YazarID))
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
            return View(yazar);
        }

        // GET: AdminPanel/Yazar/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Yazarlar == null)
            {
                return NotFound();
            }

            var yazar = await _context.Yazarlar
                .FirstOrDefaultAsync(m => m.YazarID == id);
            if (yazar == null)
            {
                return NotFound();
            }

            return View(yazar);
        }

        // POST: AdminPanel/Yazar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Yazarlar == null)
            {
                return Problem("Entity set 'KutuphaneDB.Yazarlar'  is null.");
            }
            var yazar = await _context.Yazarlar.FindAsync(id);
            if (yazar != null)
            {
                _context.Yazarlar.Remove(yazar);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool YazarExists(int id)
        {
          return _context.Yazarlar.Any(e => e.YazarID == id);
        }
    }
}
