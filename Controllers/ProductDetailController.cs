using doanw.Models;
using doanw.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace doanw.Controllers
{
    public class ProductDetailController : Controller
    {
        private readonly DataContext _context;
        public ProductDetailController(DataContext context)
        {
            _context = context;
        }

        [Route("/chitietsp-{id:int}.html", Name = "Index")]
        public IActionResult Index(int? id)
        {

            //var list = _context.Chitietspp.FirstOrDefault(m => m.ProductSCID == id);
            var list = _context.Chitietspp.Find(id);
            Functions._ProductSCID = list.ProductSCID;

            return View(list);

        }
        
        public IActionResult Create()
        {
            
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Cart mn)
        {
            if (ModelState.IsValid)
            {
                _context.Carts.Add(mn);
                _context.SaveChanges();
                return RedirectToAction("Index", "Cart");
            }
            return View(mn);
        }
    }
}
