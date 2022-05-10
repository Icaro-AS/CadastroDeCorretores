using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CadastroCorretores.Models;

namespace CadastroCorretores.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CorretorController : ControllerBase
    {
        private readonly CorretorDbContext _context;

        public CorretorController(CorretorDbContext context)
        {
            _context = context;
        }

        // GET: api/Corretor
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CorretorModel>>> GetcorretorModels()
        {
            return await _context.corretorModels.ToListAsync();
        }

        // GET: api/Corretor/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CorretorModel>> GetCorretorModel(int id)
        {
            var corretorModel = await _context.corretorModels.FindAsync(id);

            if (corretorModel == null)
            {
                return NotFound();
            }

            return corretorModel;
        }

        // PUT: api/Corretor/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCorretorModel(int id, CorretorModel corretorModel)
        {
            if (id != corretorModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(corretorModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CorretorModelExists(id))
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

        // POST: api/Corretor
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CorretorModel>> PostCorretorModel(CorretorModel corretorModel)
        {
            _context.corretorModels.Add(corretorModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCorretorModel", new { id = corretorModel.Id }, corretorModel);
        }

        // DELETE: api/Corretor/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCorretorModel(int id)
        {
            var corretorModel = await _context.corretorModels.FindAsync(id);
            if (corretorModel == null)
            {
                return NotFound();
            }

            _context.corretorModels.Remove(corretorModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CorretorModelExists(int id)
        {
            return _context.corretorModels.Any(e => e.Id == id);
        }
    }
}
