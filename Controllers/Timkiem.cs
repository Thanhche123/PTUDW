using doanw.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

namespace doanw.Controllers
{
	public class Timkiem : Controller
	{
		private readonly DataContext _context;
		public Timkiem(DataContext context)
		{
			_context = context;
		}
		[HttpPost]
		public IActionResult Index(string name)
		{
			if(name == null)
			{
				NotFound();
				
			}
			var list = (from m in _context.Sanphams
						where m.ProductName.Contains(name)
						select m).ToList();
			return View(list);
		}
        public IActionResult ASC()
        {
			var list = (from m in _context.Sanphams
						
						orderby m.Price
						select m).ToList();

            return View();
        }
     
    }
}
