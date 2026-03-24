using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NotKayitSistemi.Models.DataContext;
using NotKayitSistemi.Models.Entities;

namespace NotKayitSistemi.Controllers
{
    public class OgrenciController : Controller
    {
        private readonly NotKayitDbContext _context;

        public OgrenciController(NotKayitDbContext context)
        {
            _context = context;
        }

        // ================= INDEX =================
        public async Task<IActionResult> Index()
        {
            var liste = await _context.OgrenciTml
                .Include(x => x.OgrenciAdresler)
                .Include(x => x.OgrenciIletisim)
                .ToListAsync();

            return View(liste);
        }

        // ================= DETAILS =================
        public async Task<IActionResult> Details(long id)
        {
            var ogrenci = await _context.OgrenciTml
                .Include(x => x.OgrenciAdresler)
                .Include(x => x.OgrenciIletisim)
                .Include(x => x.OgrenciDersler)
                    .ThenInclude(od => od.DersTml)
                .Include(x => x.Notlar)
                    .ThenInclude(n => n.DersTml)
                .Include(x => x.Notlar)
                    .ThenInclude(n => n.NotKodTml)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (ogrenci == null)
                return NotFound();

            return View(ogrenci);
        }

        // ================= CREATE =================
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(OgrenciTml model)
        {
            if (!ModelState.IsValid)
                return View(model);

            _context.OgrenciTml.Add(model);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // ================= EDIT =================
        public async Task<IActionResult> Edit(long id)
        {
            var ogrenci = await _context.OgrenciTml
                .Include(x => x.OgrenciAdresler)
                .Include(x => x.OgrenciIletisim)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (ogrenci == null)
                return NotFound();

            return View(ogrenci);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, OgrenciTml model)
        {
            if (id != model.Id)
                return NotFound();

            var ogrenci = await _context.OgrenciTml.FindAsync(id);

            if (ogrenci == null)
                return NotFound();

            ogrenci.Ad = model.Ad;
            ogrenci.Soyad = model.Soyad;
            ogrenci.DogumTarihi = model.DogumTarihi;
            ogrenci.Cinsiyet = model.Cinsiyet;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // ================= DELETE =================
        public async Task<IActionResult> Delete(long id)
        {
            var ogrenci = await _context.OgrenciTml
                .FirstOrDefaultAsync(x => x.Id == id);

            if (ogrenci == null)
                return NotFound();

            return View(ogrenci);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var ogrenci = await _context.OgrenciTml
                .Include(x => x.OgrenciAdresler)
                .Include(x => x.OgrenciIletisim)
                .Include(x => x.OgrenciDersler)
                .Include(x => x.Notlar)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (ogrenci == null)
                return NotFound();

            if (ogrenci.OgrenciAdresler.Any())
                _context.OgrenciAdres.RemoveRange(ogrenci.OgrenciAdresler);

            if (ogrenci.OgrenciIletisim.Any())
                _context.OgrenciIletisim.RemoveRange(ogrenci.OgrenciIletisim);

            if (ogrenci.OgrenciDersler.Any())
                _context.OgrenciDers.RemoveRange(ogrenci.OgrenciDersler);

            if (ogrenci.Notlar.Any())
                _context.NotTml.RemoveRange(ogrenci.Notlar);

            _context.OgrenciTml.Remove(ogrenci);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
