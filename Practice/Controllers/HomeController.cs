using Microsoft.AspNetCore.Mvc;
using Practice.DI;
using Practice.Models;
using System.Diagnostics;

namespace Practice.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        ISimpleInterest _simpleInterest;

        public HomeController(ILogger<HomeController> logger,ISimpleInterest simpleInterest)
        {
            _logger = logger;
            _simpleInterest = simpleInterest;
        }

        public IActionResult Index()
        {
            var result = _simpleInterest.Calculate(10000, 2, 5);
            ViewData["Message"] = result;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
