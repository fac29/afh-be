using afh_db.Models;
using Microsoft.EntityFrameworkCore;

namespace afh_db.Libraries;

public interface IMovieLibrary
{
    Task<Movie?> GetMovieById(int id);
    Task DeleteMovie(Movie movie);
    Task<List<Movie>> GetMoviesList();
    Task AddMovie(Movie newMovie);
    Task EditMovie(Movie editMovie, Movie existingMovie);
}

public class MovieLibrary : IMovieLibrary
{
    private readonly MovieDBContext _context;

    public MovieLibrary(MovieDBContext context)
    {
        _context = context;
    }

    public async Task DeleteMovie(Movie movie)
    {
        _context.Movies.Remove(movie);
        await _context.SaveChangesAsync();
    }

    public async Task<Movie?> GetMovieById(int id)
    {
        return await _context.Movies.FindAsync(id);
    }

    public async Task<List<Movie>> GetMoviesList()
    {
        return await _context.Movies.ToListAsync();
    }

    public async Task AddMovie(Movie newMovie)
    {
        await _context.Movies.AddAsync(newMovie);
        await _context.SaveChangesAsync();
    }

    public async Task EditMovie(Movie editMovie, Movie existingMovie)
    {
        foreach (var property in editMovie.GetType().GetProperties())
        {
            var value = property.GetValue(editMovie);
            if (value != null)
            {
                _context.Entry(existingMovie).Property(property.Name).CurrentValue = value;
            }
        }
        await _context.SaveChangesAsync();
    }
}
