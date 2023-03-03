﻿using System;
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

    public class KategoriakController : ControllerBase
    {
        private readonly ITBoltContext _context;

        public KategoriakController(ITBoltContext context)
        {
            _context = context;
        }

        // GET: api/kategoriak/kategoria1
        [HttpGet("{kategoriaID}")]
        public async Task<ActionResult<Kategoria>> GetKategoria(string kategoriaID)
        {
            var value = await _context.kategoria.FindAsync(kategoriaID);

            if (value == null)
            {
                return NotFound();
            }

            return value;
        }

        // PUT: /api/kategoriak/kategoria1

        [HttpPut("{kategoriaID}")]

        public async Task<IActionResult> PutKategoria(string kategoriaID, Kategoria kategoria)
        {
            if (kategoriaID != kategoria.kategoriaID)
            {
                return BadRequest();
            }

            _context.Entry(kategoria).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!(KategoriaExists(kategoriaID)))
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

        //POST: /api/kategoriak
        //{
        //    "kategoriaID" : "12",
        //    "kategoria_nev" : "kategoria1"
        //}
        [HttpPost]
        public async Task<ActionResult<Kategoria>> PostKategoria(Kategoria kategoria)
        {
            _context.kategoria.Add(kategoria);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetKategoria", new { id = kategoria.kategoriaID }, kategoria);
        }


        // DELETE: /api/kategoriak/kategoria1
        [HttpDelete("{kategoriaID}")]
        public async Task<IActionResult> DeleteKategoria(string kategoriaID)
        {
            var value = await _context.kategoria.FindAsync(kategoriaID);
            if (value == null)
            {
                return NotFound();
            }
            _context.kategoria.Remove(value);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool KategoriaExists(string kategoriaID)
        {
            return _context.kategoria.Any(e => e.kategoriaID == kategoriaID);
        }
    }
}
