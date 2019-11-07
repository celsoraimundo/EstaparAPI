using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EstaparAPI.Models;

namespace EstaparAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManobristasController : ControllerBase
    {
        private readonly essenceestaparContext _context;

        public ManobristasController(essenceestaparContext context)
        {
            _context = context;
        }

        // GET: api/Manobristas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Manobrista>>> GetManobrista()
        {
            return await _context.Manobrista.ToListAsync();
        }

        // GET: api/Manobristas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Manobrista>> GetManobrista(int id)
        {
            var manobrista = await _context.Manobrista.FindAsync(id);

            if (manobrista == null)
            {
                return NotFound();
            }

            return manobrista;
        }

        // PUT: api/Manobristas/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutManobrista(int id, Manobrista manobrista)
        {
            if (id != manobrista.Id)
            {
                return BadRequest();
            }

            _context.Entry(manobrista).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ManobristaExists(id))
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

        // POST: api/Manobristas
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Manobrista>> PostManobrista(Manobrista manobrista)
        {
            _context.Manobrista.Add(manobrista);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetManobrista", new { id = manobrista.Id }, manobrista);
        }

        // DELETE: api/Manobristas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Manobrista>> DeleteManobrista(int id)
        {
            var manobrista = await _context.Manobrista.FindAsync(id);
            if (manobrista == null)
            {
                return NotFound();
            }

            _context.Manobrista.Remove(manobrista);
            await _context.SaveChangesAsync();

            return manobrista;
        }

        private bool ManobristaExists(int id)
        {
            return _context.Manobrista.Any(e => e.Id == id);
        }
    }
}
