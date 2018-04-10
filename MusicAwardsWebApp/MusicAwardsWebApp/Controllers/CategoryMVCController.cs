using Microsoft.AspNetCore.Mvc;
using MusicAwardsWebApp.Models;
using MusicAwardsWebApp.Repository;
using MusicAwardsWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MusicAwardsWebApp.Controllers
{
    public class CategoryMVC : Controller
    {
        IServices Services;
        IIPAddressManager iPAddress;
        public CategoryMVC(IServices services, IIPAddressManager iP)
        {
            this.Services = services;
            iPAddress = iP;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var categories = new CategoryIndexViewModel()
            {
                AwardCategories = Services.GetCategories()
            };

            return View(categories);
        }

        [HttpPost]
        public IActionResult AddNew(AddNewViewModel vm)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);

                var category = new AwardCategory()
                {
                    Category = vm.Category,
                    Description = vm.Description
                };

                var result = this.Services.SaveCategory(category);
                if (result != null)
                {
                    return RedirectToAction("Index");
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        public IActionResult Result(int Id)
        {
            var category = Services.GetCategory(Id);

            if (category == null) return NotFound();

            var catNominees = Services.Results(Id);
            var vm = new CategoryResultViewModel()
            {
                Category = category.Category,
                Description = category.Description,
                votes = catNominees
            };

            ViewBag.Title = "Voting Rusults";

            return View(vm);
        }

        public IActionResult Delete(int Id)
        {
            try
            {
                var category = Services.DeleteCategory(Id);
                if (category == true)
                    return RedirectToAction("Index");
                else
                    return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        public IActionResult AddNominees(int id)
        {
            var category = Services.GetCategory(id);
            var nominees = Services.GetNominees();
            IEnumerable<Nominee> finalNominess;
            if (category.Category.Contains("female"))
            {
                finalNominess = nominees.Where(n => n.Gender == "F");
            }
            else if (category.Category.Contains("male"))
            {
                finalNominess = nominees.Where(n => n.Gender == "M");
            }
            else
            {
                finalNominess = nominees;
            }

            var categoryNominees = category.Nominees;
            List<Nominee> newNominess = new List<Nominee>();
            foreach (var nom in categoryNominees)
            {
                var nominee = Services.GetNominee(nom.NomineeId);
                newNominess.Add(nominee);
            }

            var model = new AddNomineesToCategoryViewModel()
            {
                Category = category,
                Nominees = finalNominess,
                CatNominees = newNominess
            };
            return View(model);
        }

        public IActionResult AddFinal(int catId, int nomId)
        {
            var category = Services.GetCategory(catId);
            var categoryNominees = category.Nominees;
            List<Nominee> newNominess = new List<Nominee>();
            foreach (var nom in categoryNominees)
            {
                var nominee = Services.GetNominee(nom.NomineeId);
                newNominess.Add(nominee);
            }

            var nomineeAnother = Services.GetNominee(nomId);
            if(newNominess.Contains(nomineeAnother)) return RedirectToAction("AddNominees", "CategoryMVC", new { id = catId });
            var result = Services.AddNomineeToCategory(catId, nomId);
            if (result == true) return RedirectToAction("AddNominees", "CategoryMVC", new { id = catId });
            return BadRequest();
        }

        public IActionResult Remove(int catId, int nomId)
        {
            var result = Services.RemoveNomineeFromCategory(catId, nomId);
            if(result == true) return RedirectToAction("AddNominees", "CategoryMVC", new { id = catId });
            return BadRequest();
        }

        public IActionResult FinalVote(int catId, int nomId)
        {
            var newModel = new Vote()
            {
                CategoryId = catId,
                NomineeId = nomId,
                PhoneIPAdress = iPAddress.GetIPAddress()
            };
            var result = Services.AddVote(newModel);
            if (result == true) return RedirectToAction("Index", "Vote");
            return BadRequest($"Award Category already voted for!");
        }
    }
}
