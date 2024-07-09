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

         [HttpPatch("EditMovie{id}")]
        public async Task<IActionResult> EditMovie([FromBody] Movie updatedMovie, int id)
        {
           // Find the existing movie by id
            var existingMovie = await _context.Movies.FindAsync(id);

            // Check if the movie exists
            if (existingMovie == null)
            {
                return NotFound(); // Return 404 Not Found if movie with id not found
            }

            // Update the existing movie properties with values from updatedMovie
            existingMovie.Title = updatedMovie.Title;
            existingMovie.Length = updatedMovie.Length;
            existingMovie.Description = updatedMovie.Description;
            existingMovie.Genre = updatedMovie.Genre;
            existingMovie.Image = updatedMovie.Image;
            existingMovie.Rating = updatedMovie.Rating;
            // Do not update CreatedAt assuming it should remain the same

            try
            {
                // Save changes to the database
                await _context.SaveChangesAsync();
                return NoContent(); // Return 204 No Content on successful update
            }
            catch (DbUpdateConcurrencyException)
            {
                // Handle concurrency exception (optional)
                return StatusCode(500); // Return 500 Internal Server Error or handle differently
            }
        }
        

         [HttpDelete("Delete{id}")]
        public async Task DeleteMovie(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie != null) 
            {
                _context.Movies.Remove(movie);
                await _context.SaveChangesAsync();
            return;
            }
        }
    }
}
