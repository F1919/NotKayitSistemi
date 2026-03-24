using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NotKayitSistemi.Models.DataContext;
using NotKayitSistemi.Models.ViewModels;

namespace NotKayitSistemi.Controllers
{
    public class ListelemeController1 : Controller
    {
        private readonly NotKayitDbContext _context;
        private readonly IMapper _mapper;

        public ListelemeController1(NotKayitDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _context.OgrenciTml.ToListAsync();

            var viewModel = _mapper.Map<List<OgrenciTmlViewModel>>(data);

            return View(viewModel);
        }
    }
}
