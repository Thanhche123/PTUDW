using doanw.Models;
using Microsoft.AspNetCore.Mvc;

namespace doanw.Controllers
{
    public class PriceController : Controller
    {
        private readonly DataContext _context;
        public PriceController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        
    }
}
