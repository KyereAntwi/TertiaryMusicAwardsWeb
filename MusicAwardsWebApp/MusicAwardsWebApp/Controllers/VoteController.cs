using Microsoft.AspNetCore.Mvc;
using MusicAwardsWebApp.Models;
using MusicAwardsWebApp.Repository;
using MusicAwardsWebApp.ViewModels;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MusicAwardsWebApp.Controllers
{
    public class VoteController : Controller
    {
        IServices Services;
        public VoteController(IServices services)
        {
            Services = services;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var categories = Services.GetCategories();
            return View(categories);
        }

        public IActionResult Vote(int catId)
        {
            var category = Services.GetCategory(catId);
            var categoryNominees = category.Nominees;
            List<Nominee> newNominess = new List<Nominee>();
            foreach (var nom in categoryNominees)
            {
                var nominee = Services.GetNominee(nom.NomineeId);
                newNominess.Add(nominee);
            }

            var ViewModels = new VoteOnCategoryViewModel()
            {
                Nominees = newNominess,
                Category = category
            };

            return View(ViewModels);
        }

        public IActionResult SummaryResults()
        {
            var categories = Services.GetCategories();
            int votes = Services.GetVotes().Count();
            var vm = new SummaryResultsViewModel()
            {
                TotalVotes = votes,
                Categories = categories
            };
            return View(vm);
        }
    }
}
