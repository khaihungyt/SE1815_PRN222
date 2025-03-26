using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PRN222_Assignment01.Models;

namespace PRN222_Assignment01.Controllers
{
    public class LecturerController : Controller
    {
        //private readonly FunewsManagementContext context;
        //public LecturerController(FunewsManagementContext context) => this.context = context;
        private FunewsManagementContext context = new FunewsManagementContext();
        // GET: LecturerController
        public ActionResult Index()
        {
           var model = context.NewsArticles.Include(n => n.Category).Include(n => n.CreatedBy).Include(n => n.Tags).Where(c => c.NewsStatus== true). ToList();
            return View(model);
        }
        public ActionResult BackToLogin()
        {
            return RedirectToAction("Login", "Account");
        }

        // GET: LecturerController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LecturerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LecturerController/Create
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

        // GET: LecturerController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LecturerController/Edit/5
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

        // GET: LecturerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LecturerController/Delete/5
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
