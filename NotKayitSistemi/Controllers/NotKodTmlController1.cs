using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NotKayitSistemi.Models.DataContext;
using NotKayitSistemi.Models.Entities;

namespace NotKayitSistemi.Controllers
{
    public class NotKodTmlController : Controller
    {
        private readonly NotKayitDbContext _context;

        public NotKodTmlController(NotKayitDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var liste = await _context.NotKodTml.ToListAsync();
            return View(liste);
        }

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(NotKodTml model)
        {
            if (!ModelState.IsValid) return View(model);

            _context.NotKodTml.Add(model);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(long id)
        {
            var kayit = await _context.NotKodTml.FindAsync(id);
            if (kayit == null) return NotFound();
            return View(kayit);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, NotKodTml model)
        {
            if (id != model.Id) return NotFound();
            if (!ModelState.IsValid) return View(model);

            _context.Update(model);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(long id)
        {
            var kayit = await _context.NotKodTml.FindAsync(id);
            if (kayit == null) return NotFound();
            return View(kayit);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var kayit = await _context.NotKodTml.FindAsync(id);
            if (kayit == null) return NotFound();

            _context.NotKodTml.Remove(kayit);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
