using afh_be.Data;
using afh_be.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace afh_be.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly MovieDBContext _context;

        public MoviesController(MovieDBContext context)
        {
            _context = context;
        }

        // Get:
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMovie()
        {
            return await _context.Movies.ToListAsync();
        }

        // Get: /Students/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> GetMovie(int id)
        {
            var movie = await _context.Movies.FindAsync(id);

            if (movie == null)
            {
                return NotFound();
            }

            return movie;
        }

          [HttpPost("AddMovie")]
        public async Task AddMovie([FromBody] Movie Object)
        {
            var movie = Object;
            if (movie != null) 
            {
                _context.Movies.Add(movie);
                await _context.SaveChangesAsync();
            }
            return;
        }

         [HttpDelete("Delete{id}")]
        public async Task DeleteMovie(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie != null) 
            {
                _context.Movies.Remove(movie);
                await _context.SaveChangesAsync();
            }
            return;
        }
    }
}
