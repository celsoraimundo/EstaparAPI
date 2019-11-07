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
    public class VeiculoManobrasController : ControllerBase
    {
        private readonly essenceestaparContext _context;

        public VeiculoManobrasController(essenceestaparContext context)
        {
            _context = context;
        }

        // GET: api/VeiculoManobras
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VeiculoManobra>>> GetVeiculoManobra()
        {
            return await _context.VeiculoManobra.ToListAsync();
        }

        // GET: api/VeiculoManobras/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VeiculoManobra>> GetVeiculoManobra(int id)
        {
            var veiculoManobra = await _context.VeiculoManobra.FindAsync(id);

            if (veiculoManobra == null)
            {
                return NotFound();
            }

            return veiculoManobra;
        }

        // PUT: api/VeiculoManobras/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVeiculoManobra(int id, VeiculoManobra veiculoManobra)
        {
            if (id != veiculoManobra.Id)
            {
                return BadRequest();
            }

            _context.Entry(veiculoManobra).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VeiculoManobraExists(id))
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

        // POST: api/VeiculoManobras
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<VeiculoManobra>> PostVeiculoManobra(VeiculoManobra veiculoManobra)
        {
            _context.VeiculoManobra.Add(veiculoManobra);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVeiculoManobra", new { id = veiculoManobra.Id }, veiculoManobra);
        }

        // DELETE: api/VeiculoManobras/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<VeiculoManobra>> DeleteVeiculoManobra(int id)
        {
            var veiculoManobra = await _context.VeiculoManobra.FindAsync(id);
            if (veiculoManobra == null)
            {
                return NotFound();
            }

            _context.VeiculoManobra.Remove(veiculoManobra);
            await _context.SaveChangesAsync();

            return veiculoManobra;
        }

        private bool VeiculoManobraExists(int id)
        {
            return _context.VeiculoManobra.Any(e => e.Id == id);
        }
    }
}
