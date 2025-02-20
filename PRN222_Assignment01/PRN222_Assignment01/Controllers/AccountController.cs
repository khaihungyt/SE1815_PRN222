using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PRN222_Assignment01.Models;

namespace PRN222_Assignment01.Controllers
{
    public class AccountController : Controller
    {
        private readonly IConfiguration _configuration;
        private FunewsManagementContext context = new FunewsManagementContext();
        public  AccountController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        // GET: AccountController
        [HttpGet]
        public IActionResult Login() => View();
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                string username = model.Username;
                string password = model.Password;
                if (username == _configuration["AdminAccount:email"] && password == _configuration["AdminAccount:password"])
                {
                    return RedirectToAction("Index", "Home");
                }
                List<SystemAccount> accounts = context.SystemAccounts.ToList();
                foreach (SystemAccount account in accounts)
                {
                    if(username == account.AccountEmail && password == account.AccountPassword)
                    {
                        if (account.AccountRole == 2)
                        {
                            return RedirectToAction("Index", "Lecturer");
                        }
                        else if (account.AccountRole == 1)
                        {
                            return RedirectToAction("Index", "Staff");
                        }
                    }
                }
                ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không đúng.");
            }
            return View(model);
        }

        // GET: AccountController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AccountController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AccountController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AccountController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AccountController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AccountController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AccountController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
