using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using NotKayitSistemi.Models.DataContext;
using NotKayitSistemi.Models.Entities;


namespace NotKayitSistemi.Controllers;

public class Ogrenci2Controller : Controller
{
    private readonly NotKayitDbContext _context;


    private readonly IMapper _mapper;
    public Ogrenci2Controller(NotKayitDbContext context)
    {
        _context = context;
    }


    public async Task<ActionResult> Index()
    {
        //var liste = await _context.OgrenciTml.ToListAsync();
        // return View(liste);
        return View();

    }

    public ActionResult Create() //Üzerinde bir şey yazmasa da bu bir HTTP GET isteğidir. Yani sadece "veriyi getir" demektir.
    {
        return View();
    }

    [HttpPost] //Bu metodun sadece bir form gönderildiğinde (buton tıklandığında) çalışacağını belirtir. Sayfa ilk açıldığında değil, "Kaydet" denildiğinde devreye girir.
    public async Task<IActionResult> Create(OgrenciTml ogrenci)//Formdaki kutucuklara yazılan tüm bilgileri bir ogrenci nesnesi içinde paketlenmiş olarak teslim alır.
                                                               //async olması, kayıt sırasında sistemin donmasını engeller.
    {
        if (ModelState.IsValid) //Güvenlik kontrolüdür. Modelde belirttiğin [Required] (zorunlu) veya MaxLength (uzunluk) kurallarına uyulmuş mu diye bakar.
                                //Eğer ad boşsa veya çok uzunsa içeri girmez.
        {
            _context.Add(ogrenci);  //Veriyi veritabanı sırasına ekler. "Bunu kaydetmek üzere listeye al" der.
            await _context.SaveChangesAsync();  //İşte asıl kayıt burada gerçekleşir. Veriler kalıcı olarak SQL veritabanına yazılır.
            return RedirectToAction(nameof(Index));//Kayıt başarılıysa kullanıcıyı "Öğrenci Listesi" (Index) sayfasına geri gönderir.
        }
        return View(ogrenci); //Eğer formda hata varsa (geçersizse), aynı sayfada kalır ki kullanıcı hatalarını düzeltebilsin.
                              //return View(); yerine return View(ogrenci); yazman daha profesyonel olur.
                              //Böylece kullanıcı hata yaptığında yazdığı diğer bilgiler (soyadı, doğum tarihi vb.) kutucuklardan silinmez, sadece hatalı olanı düzeltmesi istenir.
    }


}
