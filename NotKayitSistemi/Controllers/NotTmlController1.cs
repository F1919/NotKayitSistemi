using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NotKayitSistemi.Models.DataContext;
using NotKayitSistemi.Models.Entities;

namespace NotKayitSistemi.Controllers
{
    public class NotTmlController : Controller
    {
        private readonly NotKayitDbContext _context;

        public NotTmlController(NotKayitDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var liste = await _context.NotTml
                .Include(x => x.OgrenciTml)
                .Include(x => x.DersTml)
                .Include(x => x.NotKodTml)
                .ToListAsync();

            return View(liste);
        }

        public IActionResult Create()
        {
            ViewData["OgrenciTmlId"] = new SelectList(_context.OgrenciTml, "Id", "Ad");
            ViewData["DersId"] = new SelectList(_context.DersTml, "Id", "DersAd");
            ViewData["NotKodTmlId"] = new SelectList(_context.NotKodTml, "Id", "Tur");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(NotTml model)
        {
            if (!ModelState.IsValid)
            {
                ViewData["OgrenciTmlId"] = new SelectList(_context.OgrenciTml, "Id", "Ad", model.OgrenciTmlId);
                ViewData["DersId"] = new SelectList(_context.DersTml, "Id", "DersAd", model.DersId);
                ViewData["NotKodTmlId"] = new SelectList(_context.NotKodTml, "Id", "Tur", model.NotKodTmlId);
                return View(model);
            }

            _context.NotTml.Add(model);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(long id)
        {
            var kayit = await _context.NotTml.FindAsync(id);
            if (kayit == null) return NotFound();

            ViewData["OgrenciTmlId"] = new SelectList(_context.OgrenciTml, "Id", "Ad", kayit.OgrenciTmlId);
            ViewData["DersId"] = new SelectList(_context.DersTml, "Id", "DersAd", kayit.DersId);
            ViewData["NotKodTmlId"] = new SelectList(_context.NotKodTml, "Id", "Tur", kayit.NotKodTmlId);
            return View(kayit);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, NotTml model)
        {
            if (id != model.Id) return NotFound();

            if (!ModelState.IsValid)
            {
                ViewData["OgrenciTmlId"] = new SelectList(_context.OgrenciTml, "Id", "Ad", model.OgrenciTmlId);
                ViewData["DersId"] = new SelectList(_context.DersTml, "Id", "DersAd", model.DersId);
                ViewData["NotKodTmlId"] = new SelectList(_context.NotKodTml, "Id", "Tur", model.NotKodTmlId);
                return View(model);
            }

            _context.Update(model);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(long id)
        {
            var kayit = await _context.NotTml
                .Include(x => x.OgrenciTml)
                .Include(x => x.DersTml)
                .Include(x => x.NotKodTml)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (kayit == null) return NotFound();
            return View(kayit);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var kayit = await _context.NotTml.FindAsync(id);
            if (kayit == null) return NotFound();

            _context.NotTml.Remove(kayit);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
