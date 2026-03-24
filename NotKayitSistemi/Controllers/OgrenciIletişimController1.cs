using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NotKayitSistemi.Models.DataContext;
using NotKayitSistemi.Models.Entities;

namespace NotKayitSistemi.Controllers
{
    public class OgrenciIletisimController : Controller
    {
        private readonly NotKayitDbContext _context;

        public OgrenciIletisimController(NotKayitDbContext context)
        {
            _context = context;
        }

        // =======================
        // LIST
        // =======================
        public async Task<IActionResult> Index()
        {
            var liste = await _context.OgrenciIletisim
                .Include(x => x.OgrenciTml)
                .ToListAsync();

            return View(liste);
        }

        // =======================
        // CREATE GET
        // =======================
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

        // =======================
        // CREATE POST
        // =======================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(OgrenciIletisim model)
        {
            if (ModelState.IsValid)
            {
                _context.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Ogrenciler = new SelectList(
                _context.OgrenciTml
                .Select(x => new {
                    x.Id,
                    AdSoyad = x.Ad + " " + x.Soyad
                }),
                "Id",
                "AdSoyad",
                model.OgrenciTmlId
            );

            return View(model);
        }

        // =======================
        // EDIT GET
        // =======================
        public async Task<IActionResult> Edit(long id)
        {
            var kayit = await _context.OgrenciIletisim.FindAsync(id);

            if (kayit == null)
                return NotFound();

            ViewBag.Ogrenciler = new SelectList(
                _context.OgrenciTml
                .Select(x => new {
                    x.Id,
                    AdSoyad = x.Ad + " " + x.Soyad
                }),
                "Id",
                "AdSoyad",
                kayit.OgrenciTmlId
            );

            return View(kayit);
        }

        // =======================
        // EDIT POST
        // =======================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(OgrenciIletisim model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Ogrenciler = new SelectList(
                    _context.OgrenciTml
                    .Select(x => new {
                        x.Id,
                        AdSoyad = x.Ad + " " + x.Soyad
                    }),
                    "Id",
                    "AdSoyad",
                    model.OgrenciTmlId
                );

                return View(model);
            }

            var kayit = await _context.OgrenciIletisim.FindAsync(model.Id);
            if (kayit == null)
                return NotFound();

            kayit.OgrenciTmlId = model.OgrenciTmlId;
            kayit.Email = model.Email;
            kayit.Telefon = model.Telefon;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // =======================
        // DELETE GET
        // =======================
        public async Task<IActionResult> Delete(long id)
        {
            var kayit = await _context.OgrenciIletisim
                .Include(x => x.OgrenciTml)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (kayit == null)
                return NotFound();

            return View(kayit);
        }

        // =======================
        // DELETE POST
        // =======================
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var kayit = await _context.OgrenciIletisim.FindAsync(id);

            if (kayit != null)
            {
                _context.OgrenciIletisim.Remove(kayit);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}