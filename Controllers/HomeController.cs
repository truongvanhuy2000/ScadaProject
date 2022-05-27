using Microsoft.AspNetCore.Mvc;
using ScadaProject.CustomFilter;
using ScadaProject.Data;
using ScadaProject.Models;
using System.Diagnostics;

namespace ScadaProject.Controllers
{
    [SessionCheck]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult UserManagement()
        {
            IEnumerable<Account> objCategoryList = _db.Accounts.ToList();
            return View(objCategoryList);
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("login", "Account");
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(Account acc)
        {
            IEnumerable<Account> objCategoryList = _db.Accounts.ToList();
            if (ModelState.IsValid)
            {
                foreach(var item in objCategoryList)
                {
                    if(item.UserName == acc.UserName)
                    {
                        TempData["Register Error"] = "Username has been used";
                        return RedirectToAction("Register");
                    }
                    _db.Accounts.Add(acc);
                    _db.SaveChanges();
                    TempData["Register Success"] = "Account created successfully";
                    return RedirectToAction("UserManagement");
                }
            }
            return View();
        }
        public IActionResult Delete(int? id)
        {
            if(id == null)
            {
                return Error();
            }
            var obj = _db.Accounts.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Accounts.Remove(obj);
            _db.SaveChanges();
            TempData["Delete Success"] = "Deleted Sucessfully";
            return RedirectToAction("UserManagement");
        }
        public string RandomProductName()
        {
            Random rand = new Random();
            int number = rand.Next(0, 5); //returns random number between 0-99
            switch (number)
            {
                case 0:
                    return "Gạo";
                case 1:
                    return "Bột Canh";
                case 2:
                    return "Lúa";
                case 3:
                    return "Bột Mỳ";
                case 4:
                    return "Hạt Tiêu";
                case 5:
                    return "Mỳ Tôm";
            }
            return null; 
        }
        public int RandomNumber(int min, int max)
        {
            Random rand = new Random();
            int number = rand.Next(min, max); //returns random number between 0-99
            return number;
        }
        public DateTime GenerateRandomDates()
        {
            var rnd = new Random(Guid.NewGuid().GetHashCode());

                var year = rnd.Next(1995, 2021);
                var month = rnd.Next(1, 13);
                var days = rnd.Next(1, DateTime.DaysInMonth(year, month) + 1);

                return new DateTime(year, month, days, rnd.Next(0, 24), rnd.Next(0, 60), rnd.Next(0, 60), rnd.Next(0, 1000));
        }
        public IActionResult ProductReport()
        {
            //for(int i = 0; i < 100; i++)
            //{
            //    Product obj = new Product();
            //    obj.ProductName = RandomProductName();
            //    obj.CreatedDateTime = GenerateRandomDates();
            //    obj.ProductionLine = RandomNumber(1, 10);
            //    obj.TotalPackage = RandomNumber(50, 100);
            //    obj.MachineNumber = RandomNumber(1, 5);
            //    obj.ProductionShift = RandomNumber(1, 4);
            //    obj.DamagedPackage = RandomNumber(0, 30);
            //    obj.EmptyPackage = RandomNumber(0, 30);
            //    _db.Products.Add(obj);
            //    _db.SaveChanges();
            //}
            IEnumerable<Product> objCategoryList = _db.Products.ToList();
            return View(objCategoryList);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}