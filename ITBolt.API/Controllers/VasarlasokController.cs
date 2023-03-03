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

    public class VasarlasokController : ControllerBase
    {
        private readonly ITBoltContext _context;

        public VasarlasokController(ITBoltContext context)
        {
            _context = context;
        }

        // GET: /api/vasarlasok/vasarloID777/7
        [HttpGet("{vasarloID}/{rendelesID}")]
        public async Task<ActionResult<Vasarlas>> GetVasarlas(string vasarloID, int rendelesID)
        {
            var vasarlas = await _context.vasarlas.FindAsync(vasarloID, rendelesID);

            if (vasarlas == null)
            {
                return NotFound();
            }

            return vasarlas;
        }

        // PUT: /api/vasarlas/vasarlas123
        [HttpPut("{rendelesID}")]

        public async Task<IActionResult> PutVasarlas(int rendelesID, Vasarlas rendeles)
        {
            if (rendelesID != rendeles.rendelesID)
            {
                return BadRequest();
            }

            _context.Entry(rendeles).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!(RendelesExists(rendelesID)))
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

        //POST: /api/vasarlasok/a1
        [HttpPost]
        public async Task<ActionResult<Vasarlas>> PostVasarlas(Vasarlas vasarlas)
        {

            _context.vasarlas.Add(vasarlas);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVasarlas", new { rendelesID = vasarlas.rendelesID }, vasarlas);
        }


        // DELETE: /api/vasarlasok/vasarloID777/7
        [HttpDelete("{vasarloID}/{rendelesID}")]
        public async Task<IActionResult> DeleteVasarlas(string vasarloID, int rendelesID)
        {
            var vasarlas = await _context.vasarlas.FindAsync(vasarloID, rendelesID);
            if (vasarlas == null)
            {
                return NotFound();
            }
            _context.vasarlas.Remove(vasarlas);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RendelesExists(int id)
        {
            return _context.vasarlas.Any(e => e.rendelesID == id);
        }
    }
}
