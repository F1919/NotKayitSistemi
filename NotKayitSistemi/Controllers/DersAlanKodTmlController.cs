using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NotKayitSistemi.Models.DataContext;
using NotKayitSistemi.Models.Entities;

namespace NotKayitSistemi.Controllers
{
    public class DersAlanKodTmlController : Controller
    {
        private readonly NotKayitDbContext _context;

        public DersAlanKodTmlController(NotKayitDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var liste = await _context.DersAlanKodTml.ToListAsync();
            return View(liste);
        }

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DersAlanKodTml model)
        {
            if (!ModelState.IsValid) return View(model);

            _context.DersAlanKodTml.Add(model);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(long id)
        {
            var kayit = await _context.DersAlanKodTml.FindAsync(id);
            if (kayit == null) return NotFound();
            return View(kayit);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, DersAlanKodTml model)
        {
            if (id != model.Id) return NotFound();
            if (!ModelState.IsValid) return View(model);

            _context.Update(model);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(long id)
        {
            var kayit = await _context.DersAlanKodTml.FindAsync(id);
            if (kayit == null) return NotFound();
            return View(kayit);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var kayit = await _context.DersAlanKodTml.FindAsync(id);
            if (kayit == null) return NotFound();

            _context.DersAlanKodTml.Remove(kayit);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
