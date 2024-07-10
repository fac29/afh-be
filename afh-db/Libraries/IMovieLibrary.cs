using afh_db.Models;
using Microsoft.EntityFrameworkCore;

namespace afh_db.Libraries;

public interface IMovieLibrary
{
    Task<Movie?> GetMovieById(int id);
    Task DeleteMovie(Movie movie);
    Task<List<Movie>> GetMoviesList();
    Task AddMovie(Movie movie);
    Task EditMovie(Movie movie);
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

    public async Task AddMovie(Movie movie)
    {
        await _context.Movies.AddAsync(movie);
        await _context.SaveChangesAsync();
    }

    public async Task EditMovie(Movie movie)
    {
        // Save changes to the database
        _context.Movies.Update(movie);
        await _context.SaveChangesAsync();
    }
}
