using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WorldCitiesAPI.Data; // Se till att denna using finns
using WorldCitiesAPI.Models; // Se till att denna using finns

namespace WorldCitiesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorldCitiesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public WorldCitiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/WorldCities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WorldCity>>> GetWorldCities()
        {
            return await _context.WorldCities
                                 .OrderByDescending(c => c.Population)
                                 .ToListAsync();
        }

        // GET: api/WorldCities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WorldCity>> GetWorldCity(int id)
        {
            var worldCity = await _context.WorldCities.FindAsync(id);

            if (worldCity == null)
            {
                return NotFound();
            }

            return worldCity;
        }

        // POST: api/WorldCities
        [HttpPost]
        public async Task<ActionResult<WorldCity>> PostWorldCity(WorldCity worldCity)
        {
            _context.WorldCities.Add(worldCity);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetWorldCity), new { id = worldCity.CityId }, worldCity);
        }

        // PUT: api/WorldCities/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWorldCity(int id, WorldCity worldCity)
        {
            if (id != worldCity.CityId)
            {
                return BadRequest();
            }

            _context.Entry(worldCity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorldCityExists(id))
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

        // DELETE: api/WorldCities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorldCity(int id)
        {
            var worldCity = await _context.WorldCities.FindAsync(id);
            if (worldCity == null)
            {
                return NotFound();
            }

            _context.WorldCities.Remove(worldCity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WorldCityExists(int id)
        {
            return _context.WorldCities.Any(e => e.CityId == id);
        }
    }
}
