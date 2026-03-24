using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NotKayitSistemi.Models.DataContext;
using NotKayitSistemi.Models.Entities;

namespace NotKayitSistemi.Controllers
{
    public class OgrenciDersController : Controller
    {
        private readonly NotKayitDbContext _context;

        public OgrenciDersController(NotKayitDbContext context)
        {
            _context = context;
        }

        // ================= INDEX =================
        public async Task<IActionResult> Index()
        {
            var liste = await _context.OgrenciDers
                .Include(x => x.OgrenciTml)
                .Include(x => x.DersTml)
                    .ThenInclude(d => d.DersAlanKodTml)
                .ToListAsync();

            return View(liste);
        }

        // ================= DETAILS =================
        public async Task<IActionResult> Details(long id)
        {
            var kayit = await _context.OgrenciDers
                .Include(x => x.OgrenciTml)
                .Include(x => x.DersTml)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (kayit == null)
                return NotFound();

            return View(kayit);
        }

        // ================= CREATE =================
        public IActionResult Create()
        {
            ViewData["OgrenciTmlId"] =
                new SelectList(_context.OgrenciTml, "Id", "Ad");

            ViewData["DersId"] =
                new SelectList(_context.DersTml, "Id", "DersAd");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(OgrenciDers model)
        {
            if (ModelState.IsValid)
            {
                _context.OgrenciDers.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["OgrenciTmlId"] =
                new SelectList(_context.OgrenciTml, "Id", "Ad", model.OgrenciTmlId);

            ViewData["DersId"] =
                new SelectList(_context.DersTml, "Id", "DersAd", model.DersId);

            return View(model);
        }

        // ================= EDIT =================
        public async Task<IActionResult> Edit(long id)
        {
            var kayit = await _context.OgrenciDers.FindAsync(id);

            if (kayit == null)
                return NotFound();

            ViewData["OgrenciTmlId"] =
                new SelectList(_context.OgrenciTml, "Id", "Ad", kayit.OgrenciTmlId);

            ViewData["DersId"] =
                new SelectList(_context.DersTml, "Id", "DersAd", kayit.DersId);

            return View(kayit);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, OgrenciDers model)
        {
            if (id != model.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(model);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        // ================= DELETE =================
        public async Task<IActionResult> Delete(long id)
        {
            var kayit = await _context.OgrenciDers
                .Include(x => x.OgrenciTml)
                .Include(x => x.DersTml)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (kayit == null)
                return NotFound();

            return View(kayit);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var kayit = await _context.OgrenciDers.FindAsync(id);

            if (kayit == null)
                return NotFound();

            _context.OgrenciDers.Remove(kayit);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
