using doanw.Models;
using doanw.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace doanw.Controllers
{
    public class CartController : Controller
    {
        private readonly DataContext _context;
        public CartController(DataContext context)
        {
            _context = context;
        }
        //  [Route("/cart-{id:int}.html", Name = "Index")]
        public IActionResult Index()
        {

            if (!Functions.IsLogin1())
                return RedirectToAction("Index", "Dangnhap");
            var list = (from m in _context.Goshang
                        select m).ToList();
            return View(list);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(Cart mn)
        {
           
           
            mn.UserID = Functions._UserID1;
			mn.ProductSCID = Functions._ProductSCID;
			mn.Quantity = 1;
			
		    _context.Carts.Add(mn);
            _context.SaveChanges();

            return View(mn);
        }
      
    }
}
