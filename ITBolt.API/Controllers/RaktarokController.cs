using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ITBolt.API.Data;
using ItBolt.Model.Entities;

namespace ITBolt.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class RaktarokController : ControllerBase
    {
        private readonly ITBoltContext _context;

        public RaktarokController(ITBoltContext context)
        {
            _context = context;
        }

        // GET: api/raktarok/raktarID123
        [HttpGet("{id}")]
        public async Task<ActionResult<Raktar>> GetRaktar(string id)
        {
            var raktar = await _context.raktar.FindAsync(id);

            if (raktar == null)
            {
                return NotFound();
            }

            return raktar;
        }

        // PUT: /api/raktarok/raktarID234
        [HttpPut("{id}")]

        public async Task<IActionResult> PutUser(string id, Raktar raktar)
        {
            if (id != raktar.raktarID)
            {
                return BadRequest();
            }

            _context.Entry(raktar).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!(RaktarExists(id)))
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

        //POST: /api/raktarok
        [HttpPost]
        public async Task<ActionResult<Raktar>> PostRaktar(Raktar raktar)
        {

            _context.raktar.Add(raktar);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetRaktar", new { id = raktar.raktarID }, raktar);
        }


        // DELETE: /api/raktarok/raktarID123
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRaktar(string id)
        {
            var raktar = await _context.raktar.FindAsync(id);
            if (raktar == null)
            {
                return NotFound();
            }
            _context.raktar.Remove(raktar);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RaktarExists(string id)
        {
            return _context.raktar.Any(e => e.raktarID == id);
        }
    }
}
