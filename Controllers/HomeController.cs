using doanw.Models;
using doanw.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Diagnostics;

namespace doanw.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DataContext _context;
        public HomeController(ILogger<HomeController> logger, DataContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
       
        public IActionResult Create()
        {
            var list = (from m in _context.Carts
                        select m).ToList();
            return View(list);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Cart mn)
        {


            mn.UserID = Functions._UserID1;
            mn.ProductSCID = Functions._ProductSCID;
            mn.Quantity = 1;
            if (ModelState.IsValid)
            {
                _context.Carts.Add(mn);
                _context.SaveChanges();
                return RedirectToAction("Index", "Cart");
            }
               

            return View(mn);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}