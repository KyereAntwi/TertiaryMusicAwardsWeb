using Microsoft.AspNetCore.Mvc;
using MusicAwardsWebApp.Models;
using MusicAwardsWebApp.Repository;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MusicAwardsWebApp.Controllers
{
    [Route("api/[controller]")]
    public class CategoryController : Controller
    {
        IServices Services;
        public CategoryController(IServices _services)
        {
            Services = _services;
        }

        // GET: api/<controller>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(this.Services.GetCategories());
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        { 
            var category = this.Services.GetCategory(id);
            if (category == null) return NotFound();
            return Ok(category);
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]AwardCategory model)
        {
            if (ModelState.IsValid)
            {
                var category = this.Services.SaveCategory(model);
                return CreatedAtAction("Get", new { id = model.Id }, category);
            }
            return BadRequest(ModelState);
        }



        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]AwardCategory value)
        {
            if (id == value.Id)
            {
                if (ModelState.IsValid)
                {
                    var category = this.Services.SaveCategory(value);
                    return CreatedAtAction("Get", new { id = value.Id }, category);
                }
                return BadRequest(ModelState);
            }
            return NotFound();
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = this.Services.DeleteCategory(id);
            if (result == false) return NotFound();
            return Accepted();
        }
    }
}
