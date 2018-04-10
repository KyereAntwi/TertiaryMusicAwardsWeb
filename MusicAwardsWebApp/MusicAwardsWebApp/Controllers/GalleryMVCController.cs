using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicAwardsWebApp.Models;
using MusicAwardsWebApp.Repository;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MusicAwardsWebApp.Controllers
{
    public class GalleryMVCController : Controller
    {
        IServices Services;

        public GalleryMVCController(IServices services)
        {
            Services = services;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            var galleries = Services.GetAllGallery();
            return View(galleries);
        }

        public async Task<IActionResult> AddNew(List<IFormFile> Images)
        {
            foreach (var image in Images)
            {
                var gallery = new Gallery();
                using (var memoryStream = new MemoryStream())
                {
                    await image.CopyToAsync(memoryStream);
                    gallery.ImageData = memoryStream.ToArray();
                    gallery.ImageMime = image.ContentType;
                }

                var result = Services.AddGallery(gallery);
            }

            return RedirectToAction("Index", "GalleryMVC");
        }

        public FileContentResult GetImage(int id)
        {
            var gallery = Services.GetGallery(id);
            if (gallery != null) return File(gallery.ImageData, gallery.ImageMime);
            return null;
        }

        public IActionResult Delete(int id)
        {
            var results = Services.DeleteGallery(id);
            if (results == true) return RedirectToAction("Index", "GalleryMVC");
            return BadRequest("Deletion was unsuccesful");
        }
    }
}
