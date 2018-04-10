using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MusicAwardsWebApp.Models;
using MusicAwardsWebApp.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MusicAwardsWebApp.Controllers
{
    [Route("api/[controller]")]
    public class CategoryNomineeController : Controller
    {
        IServices Services;
        public CategoryNomineeController(IServices services)
        {
            this.Services = services;
        }
        // GET: api/<controller>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var category = this.Services.GetCategory(id);
            var innerNominees = this.Services.GetCategoryNominees(id);
            List<Nominee> nominees = new List<Nominee>();
            foreach (var nominee in innerNominees)
            {
                var newNom = Services.GetNominee(nominee.NomineeId);
                nominees.Add(newNom);
            }
            return Ok(nominees);
        }
    }
}
