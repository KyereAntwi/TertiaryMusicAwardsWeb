using Microsoft.AspNetCore.Mvc;
using MusicAwardsWebApp.Models;
using MusicAwardsWebApp.Repository;
using System;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MusicAwardsWebApp.Controllers
{
    [Route("api/[controller]")]
    public class NomineesController : Controller
    {
        IServices Services;
        public NomineesController(IServices services)
        {
            this.Services = services;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Nominee> Get()
        {
            return Services.GetNominees();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var nominee = Services.GetNominee(id);
            return Ok(nominee);
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]Nominee value)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var nominee = Services.SaveNominee(value);
                    return CreatedAtAction("Get", new { id = value.Id }, nominee);
                }
                return BadRequest(ModelState);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Nominee value)
        {
            if (id != value.Id) return BadRequest($"{value.Id} does not match with {id} ");
            try
            {
                if (ModelState.IsValid)
                {
                    var nominee = Services.SaveNominee(value);
                    return CreatedAtAction("Get", new { id = value.Id }, nominee);
                }
                return BadRequest(ModelState);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var nominee = Services.GetNominee(id);
            if (nominee == null) return NotFound();
            try
            {
                var result = Services.DeleteNominee(id);
                if (result != false)
                {
                    return Accepted();
                }
                return BadRequest();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
