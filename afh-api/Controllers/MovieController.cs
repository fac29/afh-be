// using afh_be.Data;
using afh_db;
using afh_db.Libraries;
using afh_db.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace afh_be.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieLibrary _movieLibrary;

        public MoviesController(IMovieLibrary movieLibrary)
        {
            _movieLibrary = movieLibrary;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMoviesList()
        {
            return await _movieLibrary.GetMoviesList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> GetMovieById(int id)
        {
            var movie = await _movieLibrary.GetMovieById(id);

            if (movie == null)
            {
                return NotFound();
            }

            return movie;
        }

        [HttpPost("")]
        public async Task AddMovie([FromBody] Movie movie)
        {
            if (movie != null)
            {
                await _movieLibrary.AddMovie(movie);
            }
            return;
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> EditMovie([FromBody] Movie updatedMovie, int id)
        {
            // Find the existing movie by id
            var existingMovie = await _movieLibrary.GetMovieById(id);

            // Check if the movie exists
            if (existingMovie == null)
            {
                return NotFound(); // Return 404 Not Found if movie with id not found
            }

            try
            {
                await _movieLibrary.EditMovie(updatedMovie);
                return NoContent();
            }
            catch (Exception)
            {
                // Handle concurrency exception (optional)
                // Log error here
                return StatusCode(500); // Return 500 Internal Server Error or handle differently
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Movie>> DeleteMovie(int id)
        {
            var movie = await _movieLibrary.GetMovieById(id);
            if (movie == null)
            {
                return NotFound();
            }
            await _movieLibrary.DeleteMovie(movie);
            return NoContent();
        }
    }
}
