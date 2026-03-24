using Microsoft.AspNetCore.Mvc;
using NotKayitSistemi.Models.DataContext;

public class TestController : Controller
{
    private readonly NotKayitDbContext _context;

    public TestController(NotKayitDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var users = _context.AppUsers.ToList(); // 🔥 DÜZELTİLDİ
        return View(users);
    }
}