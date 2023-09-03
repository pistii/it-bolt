using ITBolt.API.Data;
using ItBolt.Model.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ItBolt.Model.DTOs;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using ApiClient.Entities;
using ApiClient.Authorization;
using ApiClient.Services;
using ApiClient.Models;
using WebApi.Authorization;
using BCrypt.Net;

namespace ITBolt.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FelhasznaloController : ControllerBase
    {
        private readonly ITBoltContext _context;
        private IFelhasznaloService _felhasznaloService;

        public FelhasznaloController(ITBoltContext context, IFelhasznaloService felhasznaloService)
        {
            _context = context;
            _felhasznaloService = felhasznaloService;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            var response = _felhasznaloService.Authenticate(model);

            if (response == null)
                return BadRequest(new { message = "Hibás felhasználónév vagy jelszó" });

            return Ok(response);
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _felhasznaloService.GetAll();
            return Ok(users);
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
        //    "nev": "ADMIN",
        //    "jelszo": "ADMIN"
        //    }
        [HttpPut("{id}")]

        public async Task<IActionResult> PutUser(int id, Felhasznalo felhasznalo)
        {
            if (id != felhasznalo.id )
            {
                return BadRequest();
            }
            var changed = BCrypt.Net.BCrypt.HashPassword(felhasznalo.jelszo);
            var user = new Felhasznalo();
            user.id = felhasznalo.id;
            user.jelszo = changed;
            user.nev = felhasznalo.nev;

            _context.Entry(user).State = EntityState.Modified;

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

        //CREATES NEW USER
        //{
        //  "nev" : "user",
        //  "jelszo" : "user"
        //}
    //POST: /api/felhasznalo
    [HttpPost]
        public async Task<ActionResult<Felhasznalo>> PostFelhasznalo(Felhasznalo felhasznalo)
        {
            var changed = BCrypt.Net.BCrypt.HashPassword(felhasznalo.jelszo);
            var user = new Felhasznalo();
            user.jelszo = changed;
            user.nev = felhasznalo.nev;

            _context.felhasznalo.Add(user);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetFelhasznalo", new { id = user.id }, felhasznalo); // a régi felhasználónevet és jelszót adja vissza nem pedig a hashelt-et
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
