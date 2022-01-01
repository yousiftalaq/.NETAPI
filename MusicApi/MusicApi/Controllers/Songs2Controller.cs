using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicApi.Data;
using MusicApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MusicApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Songs2Controller : ControllerBase
    {
        string FIREBASE_KEY = "https://net-core-38c79-default-rtdb.firebaseio.com/";

        private readonly ApiDbContext _db;
        
        public Songs2Controller(ApiDbContext db)
        {
            _db = db;
        }
        // GET: api/<Songs2Controller>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _db.Songs.ToListAsync()); // 200
          
        }

        // GET api/<Songs2Controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var song = await _db.Songs.FindAsync(id);
            if (song == null)
            {
                return NotFound("No record found against this Id");
            }
            else
            {
                return Ok( song);
            }
        }

        // POST api/<Songs2Controller>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Song song)
        {
           await _db.Songs.AddAsync(song);
           await _db.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created); // 201
        }
     

       

        // PUT api/<Songs2Controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Song songObj)
        {
            var song = await _db.Songs.FindAsync(id);
            if (song == null)
            {
                return NotFound("No record found against this Id");
            }
            else
            {
                song.Title = songObj.Title;
                song.Language = songObj.Language;
                song.Duration = songObj.Duration; 
              await  _db.SaveChangesAsync();
                return Ok("Record Updated Successfully");
            }
        }

        // DELETE api/<Songs2Controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var song = await _db.Songs.FindAsync(id);
            if (song == null)
            {
                return NotFound("No record found against this Id");
            }
            else
            {
                _db.Songs.Remove(song);
               await _db.SaveChangesAsync();
                return Ok("Record Deleted");
            }
        }
    }
}
