using ITBolt.API.Data;
using ItBolt.Model.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ItBolt.Model.DTOs;

namespace ITBolt.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class FelhasznaloController : ControllerBase
    {
        private readonly ITBoltContext _context;
        
        public FelhasznaloController(ITBoltContext context)
        {
            _context = context;
        }


        //GET: api/Felhasznalo
        //[HttpGet]
        // public Task<TableDTO<Felhasznalo>> GetAll(
        //     string nev = "",
        //     string jelszo = "")
        // {
        //     var query = _context.felhasznalo.Where(query => query.nev == nev && query.jelszo == jelszo);


        //     List<Felhasznalo> data = new List<Felhasznalo>();

        //     data = query.ToList();

        //     return Task.FromResult(new TableDTO<Felhasznalo>(data, 1));
        // }

        // GET: api/Felhasznalo
        [HttpGet]
        public async Task<IActionResult> GetAll(
            string nev = "",
            string jelszo = "")
        {
            var query = _context.felhasznalo.Any(q => q.nev == nev && q.jelszo == jelszo);

            if (!query)
            {
                return NotFound();
            }
            return Ok(query);
        }

        // GET: api/Felhasznalo/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Felhasznalo>> GetFelhasznalo(int id)
        {
            var user = await _context.felhasznalo.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT: /api/felhasznalo/1
        //    {
        //    "id" : 1,
        //    "nev": "afdfhdfh",
        //    "jelszo": "akombakom"
        //    }
        [HttpPut("{id}")]

        public async Task<IActionResult> PutUser(int id, Felhasznalo felhasznalo)
        {
            if (id != felhasznalo.id )
            {
                return BadRequest();
            }

            _context.Entry(felhasznalo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!(UserExists(id)))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        //POST: /api/felhasznalo
        [HttpPost]
        public async Task<ActionResult<Felhasznalo>> PostFelhasznalo(Felhasznalo felhasznalo)
        {
            
            _context.felhasznalo.Add(felhasznalo);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetFelhasznalo", new { id = felhasznalo.id }, felhasznalo);
        }


        // DELETE: /api/felhasznalo/2
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.felhasznalo.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            _context.felhasznalo.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return _context.felhasznalo.Any(e => e.id == id);
        }
    }
}
