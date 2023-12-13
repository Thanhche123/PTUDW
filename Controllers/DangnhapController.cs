using doanw.Areas.Admin.Models;
using doanw.Models;
using doanw.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;
using System;

namespace doanw.Controllers
{
    public class DangnhapController : Controller
    {
        private readonly DataContext _dataContext;
        public DangnhapController(DataContext dataContext)
        {
            _dataContext= dataContext;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Users user)
        {
            if (user == null)
            {
                return NotFound();
            }
           
            string pw = Functions.MD5Password(user.Password);

            var check = _dataContext.Userss.Where(m => (m.Email == user.Email) && (m.Password == pw)).FirstOrDefault();
            if (check == null)
            {
                Functions._Message1 = "Invalid Email or Password";
                return RedirectToAction("Index", "Dangnhap");
            }
            Functions._Message1 = string.Empty;
            Functions._UserID1 = check.UserID;
            Functions._Password1 = user.Password;
            Functions._UserName1 = string.IsNullOrEmpty(check.UserName) ? string.Empty : check.UserName;
            Functions._Email1 = string.IsNullOrEmpty(check.Email) ? string.Empty : check.Email;
         
            return RedirectToAction("Index", "Home");
        }
    }
}
