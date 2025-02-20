using System.Diagnostics;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(ProductEditModel model)
        {
            HomeModel message = new HomeModel();
            if (ModelState.IsValid)
            {
                ViewBag.Message = "product " + model.Name + " created successfully";
            }
            else
            {
                ViewBag.Message = "Failed to create the product. Please try again";
            }
            return View(message);
        }   
        public IActionResult Privacy()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(ProductEditModel model)
        {
            string message = "";
            if (ModelState.IsValid)
            {
                ViewBag.Message = "product " + model.Name + " created successfully";
            }
            else
            {
                ViewBag.Message = "Failed to create the product. Please try again";
            }
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
