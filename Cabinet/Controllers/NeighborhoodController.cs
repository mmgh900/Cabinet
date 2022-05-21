using Cabinet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cabinet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NeighborhoodController : ControllerBase
    {
        private readonly CabinetContext _context;

        public NeighborhoodController(CabinetContext context)
        {
            _context = context;
        }

        // GET: api/Neighborhood
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Neighborhood>>> GetNeighborhoods()
        {
            if (_context.Neighborhoods == null)
            {
                return NotFound();
            }

            return await _context.Neighborhoods.ToListAsync();
        }

        // GET: api/Neighborhood/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Neighborhood>> GetNeighborhood(long id)
        {
            if (_context.Neighborhoods == null)
            {
                return NotFound();
            }

            var neighborhood = await _context.Neighborhoods.FindAsync(id);

            if (neighborhood == null)
            {
                return NotFound();
            }

            return neighborhood;
        }

        // PUT: api/Neighborhood/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNeighborhood(long id, Neighborhood neighborhood)
        {
            if (id != neighborhood.Id)
            {
                return BadRequest();
            }

            _context.Entry(neighborhood).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NeighborhoodExists(id))
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

        // POST: api/Neighborhood
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Neighborhood>> PostNeighborhood(Neighborhood neighborhood)
        {
            if (_context.Neighborhoods == null)
            {
                return Problem("Entity set 'CabinetContext.Neighborhoods'  is null.");
            }

            _context.Neighborhoods.Add(neighborhood);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNeighborhood", new { id = neighborhood.Id }, neighborhood);
        }

        // DELETE: api/Neighborhood/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNeighborhood(long id)
        {
            if (_context.Neighborhoods == null)
            {
                return NotFound();
            }

            var neighborhood = await _context.Neighborhoods.FindAsync(id);
            if (neighborhood == null)
            {
                return NotFound();
            }

            _context.Neighborhoods.Remove(neighborhood);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NeighborhoodExists(long id)
        {
            return (_context.Neighborhoods?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}