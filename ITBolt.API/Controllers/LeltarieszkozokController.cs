using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ITBolt.API.Data;
using ItBolt.Model.Entities;

namespace ITBolt.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class LeltarieszkozokController : ControllerBase
    {
        private readonly ITBoltContext _context;

        public LeltarieszkozokController(ITBoltContext context)
        {
            _context = context;
        }

        // GET: api/leltarieszkozok/
        [HttpGet("{boltID}")]
        public async Task<ActionResult<Leltarieszkoz>> GetLeltarieszkoz(int boltID)
        {
            var leltarieszkoz = await _context.leltarieszkoz.FindAsync(boltID);

            if (leltarieszkoz == null)
            {
                return NotFound();
            }

            return leltarieszkoz;
        }

        // PUT: /api/leltarieszkoz/KisBolt
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLeltarieszkoz(int leltarieszkozAZ, Leltarieszkoz leltarieszkoz)
        {
            if (leltarieszkozAZ != leltarieszkoz.eszkozID)
            {
                return BadRequest();
            }

            _context.Entry(leltarieszkoz).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!(LeltarieszkozExists(leltarieszkozAZ)))
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

        //POST: /api/leltarieszkoz
        [HttpPost]
        public async Task<ActionResult<Leltarieszkoz>> PostLeltarieszkoz(Leltarieszkoz leltarieszkoz)
        {

            _context.leltarieszkoz.Add(leltarieszkoz);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetLeltarieszkoz", new { id = leltarieszkoz.eszkozID }, leltarieszkoz);
        }


        // DELETE: /api/leltarieszkoz/leltarieszkozAZ
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLeltarieszkoz(int leltarieszkozAZ)
        {
            var leltarieszkoz = await _context.leltarieszkoz.FindAsync(leltarieszkozAZ);
            if (leltarieszkoz == null)
            {
                return NotFound();
            }
            _context.leltarieszkoz.Remove(leltarieszkoz);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LeltarieszkozExists(int leltarieszkozAZ)
        {
            return _context.leltarieszkoz.Any(e => e.eszkozID == leltarieszkozAZ);
        }
    }
}
