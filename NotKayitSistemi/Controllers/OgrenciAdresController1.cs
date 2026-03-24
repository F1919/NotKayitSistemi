using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NotKayitSistemi.Models.DataContext;
using NotKayitSistemi.Models.Entities;

namespace NotKayitSistemi.Controllers
{
    public class OgrenciAdresController : Controller
    {
        private readonly NotKayitDbContext _context;

        public OgrenciAdresController(NotKayitDbContext context)
        {
            _context = context;
        }

        // ================= INDEX =================
        public async Task<IActionResult> Index()
        {
            var liste = await _context.OgrenciAdres
                .Include(x => x.OgrenciTml)
                .ToListAsync();

            return View(liste);
        }

        // ================= CREATE GET =================
        public IActionResult Create()
        {
            ViewBag.Ogrenciler = new SelectList(
                _context.OgrenciTml
                .Select(x => new {
                    x.Id,
                    AdSoyad = x.Ad + " " + x.Soyad
                }),
                "Id",
                "AdSoyad"
            );

            return View();
        }

        // ================= CREATE POST =================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(OgrenciAdres model)
        {
            if (ModelState.IsValid)
            {
                _context.OgrenciAdres.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Ogrenciler = new SelectList(_context.OgrenciTml, "Id", "Ad", model.OgrenciTmlId);
            return View(model);
        }

        // ================= EDIT GET =================
        public async Task<IActionResult> Edit(long id)
        {
            var adres = await _context.OgrenciAdres.FindAsync(id);

            if (adres == null)
                return NotFound();

            ViewBag.Ogrenciler = new SelectList(
                _context.OgrenciTml,
                "Id",
                "Ad",
                adres.OgrenciTmlId
            );

            return View(adres);
        }

        // ================= EDIT POST =================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, OgrenciAdres model)
        {
            if (id != model.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(model);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Ogrenciler = new SelectList(
                _context.OgrenciTml,
                "Id",
                "Ad",
                model.OgrenciTmlId
            );

            return View(model);
        }

        // ================= DELETE GET =================
        public async Task<IActionResult> Delete(long id)
        {
            var adres = await _context.OgrenciAdres
                .Include(x => x.OgrenciTml)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (adres == null)
                return NotFound();

            return View(adres);
        }

        // ================= DELETE POST =================
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var adres = await _context.OgrenciAdres.FindAsync(id);

            if (adres == null)
                return NotFound();

            _context.OgrenciAdres.Remove(adres);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
