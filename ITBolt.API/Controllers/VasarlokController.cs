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

    public class VasarlokController : ControllerBase
    {
        private readonly ITBoltContext _context;

        public VasarlokController(ITBoltContext context)
        {
            _context = context;
        }

        // GET: api/vasarlok/a1
        [HttpGet("{vasarloID}")]
        public async Task<ActionResult<Vasarlo>> GetVasarlo(int vasarloID)
        {
            var vasarlo = await _context.vasarlo.FindAsync(vasarloID);

            if (vasarlo == null)
            {
                return NotFound();
            }

            return vasarlo;
        }

        // PUT: /api/vasarlok/a1
        [HttpPut("{vasarloID}")]

        public async Task<IActionResult> putVasarlo(int vasarloID, Vasarlo vasarlo)
        {
            if (vasarloID != vasarlo.vasarloID)
            {
                return BadRequest();
            }

            _context.Entry(vasarlo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!(VasarloExists(vasarloID)))
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

        //POST: /api/vasarlok
        [HttpPost]
        public async Task<ActionResult<Vasarlo>> PostVasarlo(Vasarlo vasarlo)
        {
            _context.vasarlo.Add(vasarlo);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetVasarlo", new { vasarloID = vasarlo.vasarloID }, vasarlo);
        }


        // DELETE: /api/vasarlo/a1
        [HttpDelete("{vasarloID}")]
        public async Task<IActionResult> DeleteVasarlo(int vasarloID)
        {
            var vasarlo = await _context.vasarlo.FindAsync(vasarloID);
            if (vasarlo == null)
            {
                return NotFound();
            }
            _context.vasarlo.Remove(vasarlo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VasarloExists(int id)
        {
            return _context.vasarlo.Any(e => e.vasarloID == id);
        }
    }
}
