using doanw.Models;
using doanw.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace doanw.Controllers
{
	public class TaikhoanController : Controller
	{
		private readonly DataContext _context;
		public TaikhoanController(DataContext context)
		{
			_context = context;
		}
		public IActionResult Index()
		{
			if (!Functions.IsLogin1())
				return RedirectToAction("Index", "Dangnhap");
			var mn = (from m in _context.Userss
					  where m.Email == Functions._Email1
						select m).FirstOrDefault();
			return View(mn);
		}
        public IActionResult Create(int? id)
        {
            var mnList = _context.Userss.Find(id);
            
            return View(mnList);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Users mn)
        {
            if (ModelState.IsValid)
            {
                
                _context.Userss.Update(mn);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mn);
        }
    }
}
