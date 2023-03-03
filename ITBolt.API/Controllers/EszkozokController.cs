using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ITBolt.API.Data;
using ItBolt.Model.Entities;


namespace ITBolt.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class EszkozokController : ControllerBase
    {
        private readonly ITBoltContext _context;

        public EszkozokController(ITBoltContext context)
        {
            _context = context;
        }

        // GET: api/Eszkozok/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Eszkoz>> GetEszkozok(string id)
        {
            var eszkoz = await _context.eszkoz.FindAsync(id);

            if (eszkoz == null)
            {
                return NotFound();
            }
            return eszkoz;
        }

        // PUT: /api/eszkozok/1
        [HttpPut("{eszkozID}")]

        public async Task<IActionResult> PutEszkozok(string eszkozID, Eszkoz eszkoz)
        {
            if (eszkoz.eszkozID != eszkozID)
            {
                return BadRequest();
            }

            _context.Entry(eszkoz).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!(EszkozExists(eszkozID)))
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

        //POST: /api/eszkozok
        [HttpPost]
        public async Task<ActionResult<Eszkoz>> PostEszkoz(Eszkoz eszkoz)
        {

            _context.eszkoz.Add(eszkoz);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetEszkozok", new { id = eszkoz.eszkozID }, eszkoz);
        }


        // DELETE: /api/eszkozok/eszkozID123
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string eszkozID)
        {
            var eszkoz = await _context.eszkoz.FindAsync(eszkozID);
            if (eszkoz == null)
            {
                return NotFound();
            }
            _context.eszkoz.Remove(eszkoz);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EszkozExists(string eszkozID)
        {
            return _context.eszkoz.Any(e => e.eszkozID == eszkozID);
        }
    }
}
