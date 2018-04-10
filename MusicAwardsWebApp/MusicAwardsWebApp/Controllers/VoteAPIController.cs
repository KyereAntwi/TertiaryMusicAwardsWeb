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
    public class VoteAPIController : Controller
    {
        IServices Services;
        public VoteAPIController(IServices services)
        {
            this.Services = services;
        }
        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]Vote model)
        {
            if (ModelState.IsValid)
            {
                var response = Services.AddVote(model);
                if (response == true) return Accepted();
                return BadRequest();
            }
            return BadRequest();
        }
    }
}
