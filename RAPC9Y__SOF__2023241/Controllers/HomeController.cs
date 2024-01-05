using Microsoft.AspNetCore.Mvc;
using RAPC9Y__SOF__2023241.Models;
using RAPC9Y_SOF_2023241.MVC.Data;
using RAPC9Y_SOF_2023241.MVC.Models;
using System.Diagnostics;

namespace RAPC9Y_SOF_2023241.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ILoLRepository _repo;

        public HomeController(ILogger<HomeController> logger, ILoLRepository repo)
        {
            _logger = logger;
            _repo = repo;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> List()
        {
            return View(_repo.ReadAll());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
