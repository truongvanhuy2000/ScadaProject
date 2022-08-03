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
        //Home Page && Index-------------------------------------------------------------
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("login", "Account");
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        //Home Page && Index-------------------------------------------------------------

        //Register && UserManagement------------------------------------------------------------------------------------------------
        public IActionResult Register()
        {
            return View();
        }
        public IActionResult UserManagement()
        {
            IEnumerable<Account> objCategoryList = _db.Accounts.ToList();
            return View(objCategoryList);
        }

        [HttpPost]
        public IActionResult Register(Account acc)
        {
            IEnumerable<Account> objCategoryList = _db.Accounts.ToList();

            if (ModelState.IsValid)
            {
                foreach (var item in objCategoryList)
                {
                    if (item.UserName == acc.UserName)
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
        [AdminCheck]
        public IActionResult Delete(int? id)
        {
            if (id == null)
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
        //Register && UserManagement------------------------------------------------------------------------------------------------

        //Setting Kip------------------------------------------------------------------------------------------------
        [HttpPost]
        public IActionResult SetKip1(SettingCaSanXuat acc)
        {
            if (acc.TimeStarMinute > 60 || acc.TimeStartHour > 24 || acc.TimeStartHour < 0 || acc.TimeStarMinute < 0)
            {
                TempData["Setting SanXuat Error"] = "Setting SanXuat Error";
                return RedirectToAction("InforSettingCaSanXuat");
            }
            IEnumerable<SettingCaSanXuat> objCategoryList = _db.SettingCaSanXuats.ToList();
            foreach (var obj in objCategoryList)
            {
                if (obj.Kip == acc.Kip)
                {
                    _db.SettingCaSanXuats.Remove(obj);
                    _db.SaveChanges(true);
                    _db.SettingCaSanXuats.Add(acc);
                    _db.SaveChanges(true);
                    return RedirectToAction("InforSettingCaSanXuat");
                }
            }
            //var obj = _db.SettingCaSanXuats.Find(acc.Kip);
            //if(obj == null)
            //{
            //    _db.SettingCaSanXuats.Add(acc);
            //    _db.SaveChanges();
            //    return RedirectToAction("InforSettingCaSanXuat");
            //}

            _db.SettingCaSanXuats.Add(acc);
            _db.SaveChanges();
            return RedirectToAction("InforSettingCaSanXuat");

        }
        //Setting Kip------------------------------------------------------------------------------------------------

        // ??????? View not found
        public IActionResult InforSettingCaSanXuat()
        {
            IEnumerable<SettingCaSanXuat> objCategoryList = _db.SettingCaSanXuats.ToList();
            return View(objCategoryList);
        }

        public IActionResult SettingPLC()
        {
            return View();
        }
        public IActionResult DeleteTruongCa(int? id)
        {
            if (id == null)
            {
                return Error();
            }
            var obj = _db.SetGeneralInformations.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.SetGeneralInformations.Remove(obj);
            _db.SaveChanges();
            TempData["Delete Success"] = "Deleted Sucessfully";
            return RedirectToAction("GeneralInformation");
        }

        public IActionResult DeleteSettingKip(int? id)
        {
            if (id == null)
            {
                return Error();
            }
            var obj = _db.SettingCaSanXuats.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.SettingCaSanXuats.Remove(obj);
            _db.SaveChanges();
            TempData["Delete Success"] = "Deleted Sucessfully";
            return RedirectToAction("InforSettingCaSanXuat");
        }

        [HttpPost]
        public IActionResult AddInfor(SetGeneralInformation acc)
        {
            int IdProcduct = 1;
            IEnumerable<SetGeneralInformation> objCategoryList = _db.SetGeneralInformations.ToList();
            foreach (var item in objCategoryList)
            {
                if (item.NameTruongCa == acc.NameTruongCa)
                {
                    TempData["Register Error"] = "Username has been used, Register failed";
                    return RedirectToAction("GeneralInformation");
                }
            }

            IdProcduct = objCategoryList.Count() + 1;

        Next:
            //acc.Id = IdProcduct;
            _db.SetGeneralInformations.Add(acc);
            _db.SaveChanges();
            TempData["Register Success"] = "Account created successfully";
            return RedirectToAction("GeneralInformation");
        }

        [HienTruongCheck]
        public IActionResult GeneralInformation()
        {
            IEnumerable<SettingCaSanXuat> Setting = _db.SettingCaSanXuats.ToList();
            return View(Setting);
        }
        [HienTruongCheck]
        public IActionResult SettingSanXuat()
        {
            IEnumerable<Product> objCategoryList = _db.Products.ToList();
            List<String> ProductList = new List<String>();
            List<ProductSummary> ProductSummaryList = new List<ProductSummary>();
            foreach (var Product in objCategoryList)
            {
                if (ProductList.Count == 0)
                {
                    ProductList.Add(Product.ProductName);
                }
                if (ProductList.Contains(Product.ProductName))
                {
                    continue;
                }
                ProductList.Add(Product.ProductName);
            }

            ViewData["ProductList"] = ProductList;
            return View();
        }

        public IActionResult UpdateInformation()
        {
            return View();
        }

        public IActionResult SettingThongSoPLCD()
        {
            IEnumerable<SettingPLC> Setting = _db.SettingPLCs.ToList();
            return View(Setting);
        }

        [HttpPost]
        public IActionResult SettingThongSoPLCD(SettingPLC acc)
        {
            IEnumerable<SettingPLC> objCategoryList = _db.SettingPLCs.ToList();
            List<SettingPLC> ProductSummaryList = new List<SettingPLC>();
            foreach (var item in objCategoryList)
            {
                if (item.DayChuyen == acc.DayChuyen)
                {
                    _db.SettingPLCs.Remove(item);
                    _db.SaveChanges();
                    break;
                }
            }
            //var obj = _db.SettingPLCs.Find(acc.DayChuyen);
            ////acc.Id = acc.DayChuyen;
            if (acc.DayChuyen != 1 && acc.DayChuyen != 2 && acc.DayChuyen != 3 && acc.DayChuyen != 4)
            {
                TempData["Register PLC fail"] = "Register Sucessfully";
                return View();
            }
            //if (obj == null)
            //{
            //foreach (var entity in _db.SettingPLCs)
            //    _db.SettingPLCs.Remove(entity);
            //_db.SaveChanges();

            //    _db.SettingPLCs.Add(acc);
            //    _db.SaveChanges();
            //    objCategoryList = _db.SettingPLCs.ToList();
            //    TempData["Register PLC Success"] = "Register Sucessfully";

            //    return View(objCategoryList);
            //} else
            //{
            //_db.SettingPLCs.Remove(obj);
;
            _db.SettingPLCs.Add(acc);
            _db.SaveChanges();
            objCategoryList = _db.SettingPLCs.ToList();


            var temp = new SettingPLC();
            SettingPLC[] evenNums = objCategoryList.ToArray();
            for (int i = 0; i < (objCategoryList.Count()); i++)
            {
                for (int j = i + 1; j < objCategoryList.Count(); j++)
                {
                    if (evenNums[i].DayChuyen > evenNums[j].DayChuyen)
                    {
                        temp = evenNums[i];
                        evenNums[i] = evenNums[j];
                        evenNums[j] = temp;
                    }
                }
                ProductSummaryList.Add(evenNums[i]);
            }
            foreach (var entity in _db.SettingPLCs)
                _db.SettingPLCs.Remove(entity);
            foreach (var entity in ProductSummaryList)
            {
                _db.SettingPLCs.Add(entity);
            }
            //}


            TempData["Register PLC Success"] = "Register Sucessfully";
            Response.Headers.Add("Refresh", "60");
            return View(objCategoryList);
        }

        //ProductReport && ShowGraph---------------------------------------------------------------------

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
        public String GenerateRandomDates()
        {
            var rnd = new Random(Guid.NewGuid().GetHashCode());

            var year = rnd.Next(1995, 2021);
            var month = rnd.Next(1, 13);
            var days = rnd.Next(1, DateTime.DaysInMonth(year, month) + 1);

            return new DateTime(year, month, days, rnd.Next(0, 24), rnd.Next(0, 60), rnd.Next(0, 60), rnd.Next(0, 1000)).ToString();
        }
        public void createRandom()
        {

            for (int i = 0; i < 30; i++)
            {
                Product obj = new Product();
                obj.CreatedDateTime = GenerateRandomDates();
                obj.ProductName = RandomProductName();
                obj.ProductionLine = RandomNumber(1, 5);
                obj.TotalPackage = RandomNumber(50, 100);
                obj.MachineNumber = RandomNumber(1, 9);
                obj.ProductionShift = RandomNumber(1, 4);
                obj.DamagedPackage = RandomNumber(0, 30);
                obj.EmptyPackage = RandomNumber(0, 30);
                _db.Products.Add(obj);
                _db.SaveChanges();
            }
        }

        public IActionResult ProductReport()
        {
            //createRandom();
            IEnumerable<Product> objCategoryList = _db.Products.ToList();
            Response.Headers.Add("Refresh", "300");
            return View(objCategoryList);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult ShowGraph()
        {
            IEnumerable<Product> objCategoryList = _db.Products.ToList();
            List<String> ProductList = new List<String>();
            List<ProductSummary> ProductSummaryList = new List<ProductSummary>();
            foreach (var Product in objCategoryList)
            {
                if (ProductList.Count == 0)
                {
                    ProductList.Add(Product.ProductName);
                }
                if (ProductList.Contains(Product.ProductName))
                {
                    continue;
                }
                ProductList.Add(Product.ProductName);
            }
            foreach (var Product in ProductList)
            {
                int sum1 = 0;
                int sum2 = 0;
                int sum3 = 0;
                var tempProduct = new ProductSummary();
                tempProduct.ProductName = Product;
                foreach (var item in objCategoryList)
                {
                    if (item.ProductName == Product)
                    {
                        sum1 += item.TotalPackage;
                        sum2 += item.DamagedPackage;
                        sum3 += item.EmptyPackage;
                    }
                }
                tempProduct.TotalAmounts = sum1;
                tempProduct.TotalDamaged = sum2;
                tempProduct.TotalEmpry = sum3;
                tempProduct.PerDamaged = sum2 * 100 / sum1;
                tempProduct.PerEmpry = sum3 * 100 / sum1;
                ProductSummaryList.Add(tempProduct);
            }
            Response.Headers.Add("Refresh", "3000");
            return View(ProductSummaryList);
        }
        //ProductReport && ShowGraph---------------------------------------------------------------------

        public IActionResult GiamSat()
        {
            IEnumerable<Product> objCategoryList = _db.Products.ToList();
            IEnumerable<SettingPLC> objCategoryList_settingplc = _db.SettingPLCs.ToList();
            List<String> ProductList = new List<String>();
            List<GiamSat> ProductSummaryList = new List<GiamSat>();
            Random rand = new Random();
            var tempProduct = new GiamSat();
            var tempProduct1 = new GiamSat();
            var tempProduct2 = new GiamSat();
            var tempProduct3 = new GiamSat();
            int sum1 = 0;
            int sum2 = 0;
            int sum3 = 0;
            int sum4 = 0;
            int sum5 = 0;
            int sum6 = 0;
            int sum7 = 0;
            int sum8 = 0;
            int sum9 = 0;
            int sum10 = 0;
            int sum11 = 0;
            int sum12 = 0;

            foreach (var obj in objCategoryList)
            {
                if (obj.ProductionLine == 1)
                {
                    sum1 += obj.TotalPackage;
                    sum2 += obj.DamagedPackage;
                    sum3 += obj.EmptyPackage;
                }

                if (obj.ProductionLine == 2)
                {
                    sum4 += obj.TotalPackage;
                    sum5 += obj.DamagedPackage;
                    sum6 += obj.EmptyPackage;
                }
                if (obj.ProductionLine == 3)
                {
                    sum7 += obj.TotalPackage;
                    sum8 += obj.DamagedPackage;
                    sum9 += obj.EmptyPackage;
                }
                if (obj.ProductionLine == 4)
                {
                    sum10 += obj.TotalPackage;
                    sum11 += obj.DamagedPackage;
                    sum12 += obj.EmptyPackage;
                }
            }
            foreach (var obj in objCategoryList_settingplc)
            {
                if (obj.DayChuyen == 1)
                {
                    tempProduct.TocDoChuan = obj.TocDoChuan;
                }

                if (obj.DayChuyen == 2)
                {
                    tempProduct1.TocDoChuan = obj.TocDoChuan;
                }

                if (obj.DayChuyen == 3)
                {
                    tempProduct2.TocDoChuan = obj.TocDoChuan;
                }

                if (obj.DayChuyen == 4)
                {
                    tempProduct3.TocDoChuan = obj.TocDoChuan;
                }
            }

            tempProduct.DayChuyen = 1;
            tempProduct.TotalAmounts = sum1;
            tempProduct.TotalDamaged = sum2;
            tempProduct.TotalEmpry = sum3;
            tempProduct.SanLuongGoi = sum1 - sum2 - sum3;
            tempProduct.PerDamaged = sum2 * 100 / sum1;
            tempProduct.PerEmpry = sum3 * 100 / sum1;
            tempProduct.HieuSuat = rand.Next(60, 95);
            ProductSummaryList.Add(tempProduct);

            tempProduct1.DayChuyen = 2;
            tempProduct1.TotalAmounts = sum4;
            tempProduct1.TotalDamaged = sum5;
            tempProduct1.TotalEmpry = sum6;
            tempProduct1.SanLuongGoi = sum4 - sum5 - sum6;
            tempProduct1.PerDamaged = sum5 * 100 / sum4;
            tempProduct1.PerEmpry = sum6 * 100 / sum4;
            tempProduct1.HieuSuat = rand.Next(60, 95);
            ProductSummaryList.Add(tempProduct1);

            tempProduct2.DayChuyen = 3;
            tempProduct2.TotalAmounts = sum7;
            tempProduct2.TotalDamaged = sum8;
            tempProduct2.TotalEmpry = sum9;
            tempProduct2.SanLuongGoi = sum7 - sum8 - sum9;
            tempProduct2.PerDamaged = sum8 * 100 / sum7;
            tempProduct2.PerEmpry = sum9 * 100 / sum7;
            tempProduct2.HieuSuat = rand.Next(60, 95);
            ProductSummaryList.Add(tempProduct2);

            tempProduct3.DayChuyen = 4;
            tempProduct3.TotalAmounts = sum10;
            tempProduct3.TotalDamaged = sum11;
            tempProduct3.TotalEmpry = sum12;
            tempProduct3.SanLuongGoi = sum10 - sum11 - sum12;
            tempProduct3.PerDamaged = sum11 * 100 / sum10;
            tempProduct3.PerEmpry = sum12 * 100 / sum10;
            tempProduct3.HieuSuat = rand.Next(60, 95);
            ProductSummaryList.Add(tempProduct3);

            Response.Headers.Add("Refresh", "3000");
            return View(ProductSummaryList);
        }
    }
}