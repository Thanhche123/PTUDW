using doanw.Utilities;
using doanw.Models;
using Microsoft.AspNetCore.Mvc;

namespace doanw.Controllers
{
    public class DangkyController : Controller
    {
        private readonly DataContext _dataContext;
        public DangkyController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Users user)
        {
            if(user == null)
            {
                return NotFound();
            }
            var check = _dataContext.Userss.Where(m=>m.Email == user.Email).FirstOrDefault();
            if(check != null)
            {
                Functions._MessageEmail1 = "Duplicate Email";
                return RedirectToAction("Index", "Dangky");
            }
            Functions._MessageEmail1 = string.Empty;
            user.Password = Functions.MD5Password(user.Password);
            _dataContext.Add(user);
            _dataContext.SaveChanges();
            return RedirectToAction("Index", "Dangnhap");
        }
    }
}
