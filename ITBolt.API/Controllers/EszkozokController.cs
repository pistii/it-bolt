using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ITBolt.API.Data;
using ItBolt.Model.Entities;
using ItBolt.Model.DTOs;

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

        //For test purposes only
        public async Task<int> GetAll()
        {
            return await _context.eszkoz.CountAsync();
        }

        // GET: api/Eszkozok
        [HttpGet]
        public async Task<TableDTO<Eszkoz>> GetAll(
            int page = 1,
            int itemsPerPage = 200,
            string? search = null,
            string? sortBy = null,
            bool ascending = true)
        {
            var query = _context.eszkoz.OrderBy(x => x.eszkoz_neve).AsQueryable();
            // Keresés
            if (!string.IsNullOrWhiteSpace(search))
            {
                search = search.ToLower();
                // Ha a keresési kulcsszó szám
                int.TryParse(search, out int szam);
                //Kedvezményes akkor 1 vagy nem kedvezményes 0 
                ulong kedvezmenyOrGaranciaQuery = 0;
                if (search.Contains("nem"))
                {
                    kedvezmenyOrGaranciaQuery = 0;
                }
                if (search.Contains("kedv") || search.Contains("gar"))
                {
                    kedvezmenyOrGaranciaQuery = 1;
                }
                // Ha dátum
                DateTime.TryParse(search, out DateTime datum);

                query = query.Where(x =>
                    x.eszkoz_neve.ToLower().Contains(search) ||
                    x.eszkoz_ara.Equals(szam) ||
                    x.eszkoz_sorozatszama.Contains(search) ||
                    x.eszkoz_gyartas_ev.Equals(datum) ||
                    x.raktar_keszlet.Equals(szam) ||
                    x.eszkoz_tipus.Contains(search) ||
                    x.kedvezmenyes_e.Equals(kedvezmenyOrGaranciaQuery)
                    );
            }

            // Sorbarendezés
            if (!string.IsNullOrWhiteSpace(sortBy))
            {
                switch (sortBy)
                {

                    case "eszkoz_neve":
                        query = ascending ? query.OrderBy(x => x.eszkoz_neve) : query.OrderByDescending(x => x.eszkoz_neve);
                        break;
                    case "eszkoz_ara":
                        query = ascending ? query.OrderBy(x => x.eszkoz_ara) : query.OrderByDescending(x => x.eszkoz_ara);
                        break;
                    case "eszkoz_sorozatszama":
                        query = ascending ? query.OrderBy(x => x.eszkoz_sorozatszama) : query.OrderByDescending(x => x.eszkoz_sorozatszama);
                        break;
                    case "raktar_keszlet":
                        query = ascending ? query.OrderBy(x => x.raktar_keszlet) : query.OrderByDescending(x => x.raktar_keszlet);
                        break;
                    case "garancialis_e":
                        query = ascending ? query.OrderBy(x => x.garancialis_e) : query.OrderByDescending(x => x.garancialis_e);
                        break;
                    case "kedvezmenyes_e":
                        query = ascending ? query.OrderBy(x => x.kedvezmenyes_e) : query.OrderByDescending(x => x.kedvezmenyes_e);
                        break;
                    case "eszkoz_tipus":
                        query = ascending ? query.OrderBy(x => x.eszkoz_tipus) : query.OrderByDescending(x => x.eszkoz_tipus);
                        break;
                    default:
                        query = ascending ? query.OrderBy(x => x.eszkoz_neve) : query.OrderByDescending(x => x.eszkoz_neve);
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
            return new TableDTO<Eszkoz>(data, totalItems);
        }


        // GET: api/Eszkozok/1
        [HttpGet("{eszkozID}")]
        public async Task<ActionResult<Eszkoz>> GetEszkozok(int eszkozID)
        {
            var eszkoz = await _context.eszkoz.FindAsync(eszkozID);

            if (eszkoz == null)
            {
                return NotFound();
            }
            return eszkoz;
        }


        // PUT: /api/eszkozok/1
        [HttpPut("{eszkozID}")]
        public async Task<IActionResult> PutEszkozok(int eszkozID, Eszkoz eszkoz)
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
            eszkoz.gyarto = null;
            eszkoz.kategoria = null;
            _context.eszkoz.Add(eszkoz);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetEszkozok", new { id = eszkoz.eszkozID }, eszkoz);
        }


        // DELETE: /api/eszkozok/2
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEszkoz(int id)
        {
            var eszkoz = await _context.eszkoz.FindAsync(id);
            if (eszkoz == null)
            {
                return NotFound();
            }
            _context.eszkoz.Remove(eszkoz);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EszkozExists(int eszkozID)
        {
            return _context.eszkoz.Any(e => e.eszkozID == eszkozID);
        }
    }
}
