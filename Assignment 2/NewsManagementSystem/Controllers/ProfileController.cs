using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewsManagementSystem.Models;

namespace NewsManagementSystem.Controllers
{
    public class ProfileController : Controller
    {
        private readonly FunewsManagementContext _context;

        public ProfileController(FunewsManagementContext context)
        {
            _context = context;
        }

        // GET: ProfileController
        public ActionResult Index()
        {
            var userIdStr = HttpContext.Request.Cookies["UserId"];
            var model = _context.SystemAccounts.FirstOrDefault(c => c.AccountId== Convert.ToInt16(userIdStr));
            return View(model);
        }
        public ActionResult Dashboard()
        {
            return RedirectToAction("StaffDashboard", "Staff");
        }

        // GET: ProfileController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProfileController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProfileController/Create
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

        // GET: ProfileController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProfileController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection form)
        {
            string accountName = form["AccountName"];
            string accountEmail = form["AccountEmail"];
            string accountPassword = form["AccountPassword"];
            
            var account = _context.SystemAccounts.FirstOrDefault(c => c.AccountId == Convert.ToInt16(id)); ;

            account.AccountName = accountName;
            account.AccountEmail = accountEmail;
            account.AccountPassword = accountPassword;
            _context.Update(account);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        // GET: ProfileController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProfileController/Delete/5
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
