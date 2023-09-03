using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ITBolt.API.Data;
using ItBolt.Model.Entities;
using ItBolt.Model.DTOs;

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

        // GET: api/RaktarokToList
        
        [HttpGet]
        [Route("RaktarokToList")]
        public async Task<ActionResult<IEnumerable<Raktar>>> GetRaktarok()
        {
            return await _context.raktar.OrderBy(x => x.raktar_neve).ToListAsync();
        }

        // GET: api/Raktarok
        [HttpGet]
        public async Task<TableDTO<Raktar>> GetAll(
            int page = 1,
            int itemsPerPage = 200,
            string? search = null,
            string? sortBy = null,
            bool ascending = true)
        {
            //név alapján rendezzük
            var query = _context.raktar.OrderBy(x => x.raktar_neve).AsQueryable();
            // Keresés
            if (!string.IsNullOrWhiteSpace(search))
            {
                search = search.ToLower();
                // Ha dátum
                DateTime.TryParse(search, out DateTime datum);

                query = query.Where(x =>
                    x.raktar_neve.ToLower().Contains(search) ||
                    x.raktar_helye.ToLower().Contains(search) ||
                    x.Berlesi_ido.Equals(datum));
            }

            // Sorbarendezés
            if (!string.IsNullOrWhiteSpace(sortBy))
            {
                switch (sortBy)
                {

                    case "raktar_neve":
                        query = ascending ? query.OrderBy(x => x.raktar_neve) : query.OrderByDescending(x => x.raktar_neve);
                        break;
                    case "raktar_helye":
                        query = ascending ? query.OrderBy(x => x.raktar_helye) : query.OrderByDescending(x => x.raktar_helye);
                        break;
                    case "Berlesi_ido":
                        query = ascending ? query.OrderBy(x => x.Berlesi_ido) : query.OrderByDescending(x => x.Berlesi_ido);
                        break;
                    default:
                        query = ascending ? query.OrderBy(x => x.raktar_neve) : query.OrderByDescending(x => x.raktar_neve);
                        break;
                }
            }

            // Összes találat kiszámítása
            int totalItems = await query.CountAsync();

            // Oldaltördelés
            if (page + itemsPerPage > 0)
            {
                query = query.Skip((page - 1) * itemsPerPage).Take(itemsPerPage);
            }
            var data = await query.ToListAsync();
            return new TableDTO<Raktar>(data, totalItems);
        }

        // GET: api/raktarok/raktarID123
        [HttpGet("{id}")]
        public async Task<ActionResult<Raktar>> GetRaktar(int id)
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

        public async Task<IActionResult> PutUser(int id, Raktar raktar)
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
        public async Task<IActionResult> DeleteRaktar(int id)
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

        private bool RaktarExists(int id)
        {
            return _context.raktar.Any(e => e.raktarID == id);
        }
    }
}
