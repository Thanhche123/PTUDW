using doanw.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace doanw.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductDetailsController : Controller
    {
        private readonly DataContext _dataContext;
        public ProductDetailsController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IActionResult Index()
        {
			
			var mnList = (from mn in _dataContext.Chitietspp
						  orderby mn.ProductName
						  select mn).ToList();
			return View(mnList);
        }
		public IActionResult Delete(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            var mn = _dataContext.Chitietspp.Find(id);
            if (mn == null)
            {
                return NotFound();
            }   
            return View(mn);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var deleChitiet = _dataContext.ProductDetailss.Find(id);
            if(deleChitiet == null)
                return NotFound();
			_dataContext.ProductDetailss.Remove(deleChitiet);
			_dataContext.SaveChanges();
			
			return RedirectToAction("Index");
        }
		public IActionResult Create()
		{
			var mnList = (from m in _dataContext.Products
						  
						  select new SelectListItem()
						  {
							  Text = m.ProductName,
							  Value = m.ProductID.ToString(),
						  } 
						  ).ToList();
			mnList.Insert(0, new SelectListItem()
			{
				Text = "--Chọn sản phẩm--",
				Value = "0"

			});

			ViewBag.mnList = mnList;
			var mnList1 = (from m in _dataContext.Sizes

						  select new SelectListItem()
						  {
							  Text = m.SizeName,
							  Value = m.SizeID.ToString(),
						  }
						  ).ToList();
			mnList1.Insert(0, new SelectListItem()
			{
				Text = "--Chọn size--",
				Value = "0"

			});

			ViewBag.mnList1 = mnList1;
			var mnList2 = (from m in _dataContext.Colors

                          select new SelectListItem()
                          {
                              Text = m.ColorName,
                              Value = m.ColorID.ToString(),
                          }
                          ).ToList();
            mnList2.Insert(0, new SelectListItem()
            {
                Text = "--Chọn màu--",
                Value = "0"

            });
            ViewBag.mnList2 = mnList2;
            /*var mnList = (from m in _dataContext.Chitietspp
						select m).ToList();*/

            return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(ProductDetails mn)
		{
			if (ModelState.IsValid)
			{
				_dataContext.ProductDetailss.Add(mn);
				_dataContext.SaveChanges();
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
			var mn = _dataContext.Chitietspp.Find(id);
			if (mn == null)
			{
				return NotFound();
			}
			var mnList = (from m in _dataContext.Products

						  select new SelectListItem()
						  {
							  Text = m.ProductName,
							  Value = m.ProductID.ToString(),
						  }
						  ).ToList();
			mnList.Insert(0, new SelectListItem()
			{
				Text = "--Chọn sản phẩm--",
				Value = "0"

			});

			ViewBag.mnList = mnList;
			var mnList1 = (from m in _dataContext.Sizes

						   select new SelectListItem()
						   {
							   Text = m.SizeName,
							   Value = m.SizeID.ToString(),
						   }
						  ).ToList();
			mnList1.Insert(0, new SelectListItem()
			{
				Text = "--Chọn size--",
				Value = "0"

			});

			ViewBag.mnList1 = mnList1;
			var mnList2 = (from m in _dataContext.Colors

						   select new SelectListItem()
						   {
							   Text = m.ColorName,
							   Value = m.ColorID.ToString(),
						   }
						  ).ToList();
			mnList2.Insert(0, new SelectListItem()
			{
				Text = "--Chọn màu--",
				Value = "0"

			});
			ViewBag.mnList2 = mnList2;

			return View(mn);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(ProductDetails mn)
		{
			if (ModelState.IsValid)
			{
				_dataContext.ProductDetailss.Update(mn);
				_dataContext.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(mn);
		}

	}
}
