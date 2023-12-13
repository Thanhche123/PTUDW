using Microsoft.AspNetCore.Mvc;
using doanw.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using doanw.Utilities;

namespace doanw.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly DataContext _context;
        public CategoryController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var mnList = _context.Categories.OrderBy(m => m.CategoryID).ToList();
            if (!Functions.IsLogin())
                return RedirectToAction("Index", "Login");
            return View(mnList);
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var mn = _context.Categories.Find(id);
            if (mn == null)
            {
                return NotFound();
            }
            return View(mn);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var deleMenu = _context.Categories.Find(id);
            if (deleMenu == null)
            {
                return NotFound();
            }
            _context.Categories.Remove(deleMenu);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Create()
        {
			var mnList = (from m in _context.Categories
						  select new SelectListItem()
						  {
							  Text = m.CategoryName,
							  Value = m.CategoryID.ToString(),
						  }).ToList();
			mnList.Insert(0, new SelectListItem()
			{
				Text = "----Select----",
				Value = "0"

			});

			ViewBag.mnList = mnList;
			return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category mn)
        {
            if (ModelState.IsValid)
            {
                _context.Categories.Add(mn);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mn);
        }
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var mn = _context.Categories.Find(id);
            if (mn == null)
            {
                return NotFound();
            }

			var mnList = (from m in _context.Categories
						  select new SelectListItem()
						  {
							  Text = m.CategoryName,
							  Value = m.CategoryID.ToString(),
						  }).ToList();
			mnList.Insert(0, new SelectListItem()
			{
				Text = "----Select----",
				Value = "0"

			});

			ViewBag.mnList = mnList;
			return View(mn);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category mn)
        {
            if (ModelState.IsValid)
            {
                _context.Categories.Update(mn);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mn);
        }
    }
}
