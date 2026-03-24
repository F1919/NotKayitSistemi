using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using NotKayitSistemi.Models;
using Microsoft.AspNetCore.Authorization;

namespace NotKayitSistemi.Controllers
{
    [Authorize] // 🔐 diğer sayfalar korumalı
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Jsga()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        // 🔥 BURASI KRİTİK (LOOP'U KESER)
        [AllowAnonymous]
        public IActionResult Error()
        {
            return View();
        }
    }
}