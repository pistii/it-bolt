using ITBolt.API.Data;
using ItBolt.Model.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ITBolt.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class BoltokController : ControllerBase
    {
        private readonly ITBoltContext _context;

        public BoltokController(ITBoltContext context)
        {
            _context = context;
        }

        // GET: /api/boltok/randomAZ1
        [HttpGet("{id}")]
        public async Task<ActionResult<Bolt>> GetBoltok(string id)
        {
            var bolt = await _context.bolt.FindAsync(id);

            if (bolt == null)
            {
                return NotFound();
            }

            return bolt;
        }

        // PUT: /api/boltok/randomAZ1
        //    {
        //    "boltID" : 1,
        //    "raktarID" : 1,
        //    "rendelesID" : "100",
        //    "bolt_neve" : "Kis Bolt KFT.",
        //    "bolt_cime" : "Kis Bolt",
        //    "nyitvatartasi_ido" "H-P 8:00 - 17:00"
        //}
        [HttpPut("{id}")]

        public async Task<IActionResult> PutBoltok(string id, Bolt bolt)
        {
            if (id != bolt.boltID)
            {
                return BadRequest();
            }

            _context.Entry(bolt).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!(BoltExists(id)))
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

        //POST: /api/boltok
        //{
        //"boltID": "randomAZ3",
        //"raktarID": null,
        //"rendelesID": 3,
        //"bolt_neve": "Közepes-Bolt KFT.",
        //"bolt_cime": "Közepes-Bolt",
        //"nyitvatartasi_ido": "H-P 8:00 - 15",
        //"raktar": null,
        //"leltarieszkoz": []
        //}
        [HttpPost]
        public async Task<ActionResult<Felhasznalo>> PostBoltok(Bolt bolt)
        {

            _context.bolt.Add(bolt);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetBoltok", new { id = bolt.boltID }, bolt);
        }


        // DELETE: /api/boltok/randomAZ3
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBolt(string id)
        {
            var bolt = await _context.bolt.FindAsync(id);
            if (bolt == null)
            {
                return NotFound();
            }
            _context.bolt.Remove(bolt);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BoltExists(string id)
        {
            return _context.bolt.Any(e => e.boltID == id);
        }
    }
}