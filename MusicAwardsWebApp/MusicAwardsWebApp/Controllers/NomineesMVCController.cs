using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicAwardsWebApp.Models;
using MusicAwardsWebApp.Repository;
using MusicAwardsWebApp.ViewModels;
using System.IO;
using System.Threading.Tasks;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MusicAwardsWebApp.Controllers
{
    public class NomineesMVCController : Controller
    {
        IServices Services;

        public NomineesMVCController(IServices repo)
        {
            this.Services = repo;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var nominees = new NomineesIndexViewModelcs()
            {
                AllNominees = Services.GetNominees()
            };

            ViewBag.Title = "Nominee Page";
            return View(nominees);
        }

        public FileContentResult GetImage(int id)
        {
            var user = Services.GetNominee(id);
            if (user != null) return File(user.Image, user.ImageMime);
            return null;
        }

        [HttpPost]
        public async Task<IActionResult> AddNew(AddNewNomineeViewModel model, IFormFile image)
        {
            if (ModelState.IsValid)
            {
                var nominee = new Nominee()
                {
                    StageName = model.StageName,
                    School = model.School,
                    Gender = model.Gender
                };
                using (var memoryStream = new MemoryStream())
                {
                    await image.CopyToAsync(memoryStream);
                    nominee.Image = memoryStream.ToArray();
                    nominee.ImageMime = image.ContentType;
                }

                var newNominee = this.Services.SaveNominee(nominee);
                if (newNominee != null) return RedirectToAction("Index", "NomineesMVC");
            }
            return BadRequest(ModelState);
        }

        public IActionResult Delete(int id)
        {
            var result = Services.DeleteNominee(id);
            if (result == true)
            {
                return RedirectToAction("Index", "NomineesMVC");
            }
            return NotFound();
        }
    }
}
