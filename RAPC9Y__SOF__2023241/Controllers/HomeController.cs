using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RAPC9Y__SOF__2023241.Models;
using RAPC9Y_SOF_2023241.MVC.Data;
using RAPC9Y_SOF_2023241.MVC.Helper;
using RAPC9Y_SOF_2023241.MVC.Models;
using System.Diagnostics;

namespace RAPC9Y_SOF_2023241.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<SiteUser> _userManager;
        private readonly ILogger<HomeController> _logger;
        private ILoLRepository _repo;

        public HomeController(UserManager<SiteUser> userManager, ILogger<HomeController> logger, ILoLRepository repo)
        {
            _userManager = userManager;
            _logger = logger;
            _repo = repo;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public async Task<IActionResult> Privacy()
        {
            var principal = this.User;
            var user = await _userManager.GetUserAsync(principal);
            return View();
        }

        private async Task<IActionResult> GetUserImage(string userid)
        {
            var user = _userManager.Users.FirstOrDefault(t => t.Id == userid);
            return new FileContentResult(user.Data, user.ContentType);
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
