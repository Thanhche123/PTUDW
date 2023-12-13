using doanw.Models;
using Microsoft.AspNetCore.Mvc;

namespace doanw.Controllers
{
    public class ProductController : Controller
    {
        private readonly DataContext _context;
        public ProductController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var list = (from m in _context.Chitietspp
                        select m).ToList();
            return View(list);
        }
        
       
    }
}
