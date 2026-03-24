using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NotKayitSistemi.Models.DataContext;
using NotKayitSistemi.Models.Entities;

namespace NotKayitSistemi.Controllers
{
    public class DersTmlController : Controller
    {
        private readonly NotKayitDbContext _context;

        public DersTmlController(NotKayitDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var liste = await _context.DersTml
                .Include(x => x.DersAlanKodTml)
                .ToListAsync();

            return View(liste);
        }

        public IActionResult Create()
        {
            ViewData["DersAlanKodId"] = new SelectList(_context.DersAlanKodTml, "Id", "Tur");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DersTml model)
        {
            if (!ModelState.IsValid)
            {
                ViewData["DersAlanKodId"] = new SelectList(_context.DersAlanKodTml, "Id", "Tur", model.DersAlanKodId);
                return View(model);
            }

            _context.DersTml.Add(model);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(long id)
        {
            var kayit = await _context.DersTml.FindAsync(id);
            if (kayit == null) return NotFound();

            ViewData["DersAlanKodId"] = new SelectList(_context.DersAlanKodTml, "Id", "Tur", kayit.DersAlanKodId);
            return View(kayit);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, DersTml model)
        {
            if (id != model.Id) return NotFound();

            if (!ModelState.IsValid)
            {
                ViewData["DersAlanKodId"] = new SelectList(_context.DersAlanKodTml, "Id", "Tur", model.DersAlanKodId);
                return View(model);
            }

            _context.Update(model);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(long id)
        {
            var kayit = await _context.DersTml
                .Include(x => x.DersAlanKodTml)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (kayit == null) return NotFound();
            return View(kayit);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var kayit = await _context.DersTml.FindAsync(id);
            if (kayit == null) return NotFound();

            _context.DersTml.Remove(kayit);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
