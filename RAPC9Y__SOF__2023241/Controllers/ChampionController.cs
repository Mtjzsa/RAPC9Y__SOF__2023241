using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RAPC9Y_SOF_2023241.MVC.Data;
using RAPC9Y_SOF_2023241.MVC.Helper;
using RAPC9Y_SOF_2023241.MVC.Models;

namespace RAPC9Y_SOF_2023241.MVC.Controllers
{
    public class ChampionController : Controller
    {
        private ILoLRepository _repo;

        public ChampionController(ILoLRepository repo)
        {
            this._repo = repo;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Champion item)
        {
                if (!ModelState.IsValid)
                {
                    return View(item);
                }
            _repo.Create(item);
            return RedirectToAction("List", "home");
        }

        [HttpGet]
        public IActionResult Delete(string id)
        {
            _repo.Delete(id);
            return RedirectToAction("List", "home");
        }

        [HttpGet]
        public IActionResult Update(string id)
        {
            var champ = _repo.Read(id);
            UpdateHelper uh = new UpdateHelper();
            uh.Champ = champ;
            return View(uh);
        }

        public IActionResult Update(UpdateHelper item, IFormFile file)
        {
            using (var stream = file.OpenReadStream())
            {
                byte[] buffer = new byte[file.Length];
                stream.Read(buffer, 0, (int)file.Length);
                string filename = item.Champ.Id + "." + file.FileName.Split('.')[1];
                item.Champ.Data = buffer;
                item.Champ.ContentType = file.ContentType;
            }
            if (!ModelState.IsValid)
            {
                return View(item.Champ);
            }
            _repo.Update(item.Champ);
            return RedirectToAction("List", "home");
        }

        public IActionResult GetImage(string id)
        {
            var champ = _repo.Read(id);
            if (champ.ContentType.Length > 3)
            {
                return new FileContentResult(champ.Data, champ.ContentType);
            }
            else
            {
                return BadRequest();
            }

        }

        public IActionResult Error()
        {
            var exceptionhandlerPathFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            var msg = exceptionhandlerPathFeature.Error.Message;
            return View("Error", msg);
        }

        
    }


    
}
