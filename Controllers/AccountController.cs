using Microsoft.AspNetCore.Mvc;
using ScadaProject.CustomFilter;
using ScadaProject.Data;
using ScadaProject.Models;

namespace ScadaProject.Controllers
{
    [SessionCheck2]
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _db;
        public AccountController(ApplicationDbContext db)
        {
            _db = db;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(Account acc )
        {
            var AccountList = _db.Accounts.ToList();
            if(acc.UserName != null && acc.Password != null)
            {
                foreach (var account in AccountList)
                {
                    if (account.UserName == acc.UserName && account.Password == acc.Password)
                    {
                        HttpContext.Session.SetString("Password", acc.Password.ToString());
                        HttpContext.Session.SetString("Username", acc.UserName.ToString());
                        return RedirectToAction("Index", "Home", new { area = "" });
                    }
                }
            }
            TempData["Login Error"] = "Wrong Username or Password";
            return RedirectToAction("login", "Account");
        }
        [HttpGet]
        public IActionResult RegisterAccount()
        {
            return View();
        }
    }
}
