using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NotKayitSistemi.Models.DataContext;
using System.Security.Claims;

public class AccountController : Controller
{
    private readonly NotKayitDbContext _context;

    public AccountController(NotKayitDbContext context)
    {
        _context = context;
    }

    [AllowAnonymous]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Login(string username, string password)
    {
        var user = _context.AppUsers
            .FirstOrDefault(x => x.Username == username && x.Password == password);

        if (user != null)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username)
            };

            var identity = new ClaimsIdentity(claims, "CookieAuth");
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync("CookieAuth", principal);

            // ✅ BURASI KRİTİK (DÜZELTİLDİ)
            return RedirectToAction("Index", "Home");
        }

        // ❌ FAIL durumunda login ekranına geri dön
        ViewBag.Error = "Kullanıcı adı veya şifre hatalı";
        return View();
    }

    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync("CookieAuth");
        return RedirectToAction("Login");
    }
}