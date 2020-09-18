using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LoginAPI.Models;

namespace LoginAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TareasClientesController : ControllerBase
    {
        private readonly DB_LoginAppContext _context;

        public TareasClientesController(DB_LoginAppContext context)
        {
            _context = context;
        }

        // GET: api/TareasClientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TareasClientes>>> GetTareasClientes()
        {
            return await _context.TareasClientes.ToListAsync();
        }

        // GET: api/TareasClientes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TareasClientes>> GetTareasClientes(int id)
        {
            var tareasClientes = await _context.TareasClientes.FindAsync(id);

            if (tareasClientes == null)
            {
                return NotFound();
            }

            return tareasClientes;
        }

        // PUT: api/TareasClientes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTareasClientes(int id, TareasClientes tareasClientes)
        {
            if (id != tareasClientes.TarCliId)
            {
                return BadRequest();
            }

            _context.Entry(tareasClientes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TareasClientesExists(id))
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

        // POST: api/TareasClientes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TareasClientes>> PostTareasClientes(TareasClientes tareasClientes)
        {
            _context.TareasClientes.Add(tareasClientes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTareasClientes", new { id = tareasClientes.TarCliId }, tareasClientes);
        }

        // DELETE: api/TareasClientes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TareasClientes>> DeleteTareasClientes(int id)
        {
            var tareasClientes = await _context.TareasClientes.FindAsync(id);
            if (tareasClientes == null)
            {
                return NotFound();
            }

            _context.TareasClientes.Remove(tareasClientes);
            await _context.SaveChangesAsync();

            return tareasClientes;
        }

        private bool TareasClientesExists(int id)
        {
            return _context.TareasClientes.Any(e => e.TarCliId == id);
        }
    }
}
