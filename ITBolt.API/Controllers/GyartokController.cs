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

    public class GyartokController : ControllerBase
    {
        private readonly ITBoltContext _context;

        public GyartokController(ITBoltContext context)
        {
            _context = context;
        }

        // GET: api/gyartok/gyarto1
        [HttpGet("{gyartoID}")]
        public async Task<ActionResult<Gyarto>> GetGyarto(string gyartoID)
        {
            var gyarto = await _context.gyarto.FindAsync(gyartoID);

            if (gyarto == null)
            {
                return NotFound();
            }

            return gyarto;
        }

        // PUT: /api/gyarto/gyarto1
        //{
        //"gyartoID" : "gyarto1",
        //"gyarto_neve" : "MSI",
        //"gyarto_szekhelye" : "Szeged"
        //}
        [HttpPut("{gyartoID}")]

        public async Task<IActionResult> PutGyarto(string gyartoID, Gyarto gyarto)
        {
            if (gyartoID != gyarto.gyartoID)
            {
                return BadRequest();
            }

            _context.Entry(gyarto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!(GyartoExists(gyartoID)))
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

        //POST: /api/gyartok
        //{
        //    "gyartoID" : "gyarto4",
        //    "gyarto_neve" : "Acer",
        //    "gyarto_szekhelye" : "Budapest"
        //}
        [HttpPost]
        public async Task<ActionResult<Gyarto>> PostGyarto(Gyarto gyarto)
        {
            _context.gyarto.Add(gyarto);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetGyarto", new { gyartoID = gyarto.gyartoID }, gyarto);
        }


        // DELETE: /api/gyartok/gyarto2
        [HttpDelete("{gyartoID}")]
        public async Task<IActionResult> DeleteGyarto(string gyartoID)
        {
            var gyarto = await _context.gyarto.FindAsync(gyartoID);
            if (gyarto == null)
            {
                return NotFound();
            }
            _context.gyarto.Remove(gyarto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GyartoExists(string gyartoID)
        {
            return _context.gyarto.Any(e => e.gyartoID == gyartoID);
        }
    }
}
