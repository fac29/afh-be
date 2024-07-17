using afh_db.Models;
using afh_shared.DTOs;
using Microsoft.EntityFrameworkCore;

namespace afh_db.Libraries;

public interface ICollectionLibrary
{
    Task<List<Collection>> GetCollectionsList();
    Task<Collection?> GetCollectionById(int id);
    Task AddCollection(Collection collection);
    Task EditCollection(Collection existingCollection, EditCollectionDto editedCollection);
    Task DeleteCollection(Collection collection);
}

public class CollectionLibrary : ICollectionLibrary
{
    private readonly MovieDBContext _context;

    public CollectionLibrary(MovieDBContext context)
    {
        _context = context;
    }

    public async Task<List<Collection>> GetCollectionsList()
    {
        return await _context.Collections
        .Include(c => c.CollectionMovies)  // Include CollectionMovies
            .ThenInclude(cm => cm.Movie)   // Then include Movie within CollectionMovies
        .ToListAsync();
    }

  public async Task<Collection?> GetCollectionById(int id)
{
    return await _context.Collections
        .Include(c => c.CollectionMovies)
        .ThenInclude(cm => cm.Movie)
        .AsNoTracking()
        .FirstOrDefaultAsync(c => c.CollectionID == id);
}

    public async Task AddCollection(Collection collection)
    {
        await _context.Collections.AddAsync(collection);
        await _context.SaveChangesAsync();
    }

  public async Task EditCollection(Collection existingCollection, EditCollectionDto editedCollection)
{
    // Update scalar properties
    existingCollection.Name = editedCollection.Name ?? existingCollection.Name;
    existingCollection.Description = editedCollection.Description ?? existingCollection.Description;
    
    var existingMovieIds = existingCollection.CollectionMovies.Select(m => m.MovieID).ToList();
    var newMovieIds = editedCollection.CollectionMovies.Select(m => m.MovieID).ToList();

    // Remove movies that are no longer in the collection
    var moviesToRemove = existingCollection.CollectionMovies.Where(m => !newMovieIds.Contains(m.MovieID)).ToList();
    foreach (var movie in moviesToRemove)
    {
        existingCollection.CollectionMovies.Remove(movie);
    }

    // Add new movies to the collection
    var moviesToAdd = newMovieIds.Except(existingMovieIds).ToList();
    foreach (var movieId in moviesToAdd)
    {
        existingCollection.CollectionMovies.Add(new CollectionMovie { MovieID = movieId });
    }

    _context.Entry(existingCollection).State = EntityState.Modified;

    try
    {
        await _context.SaveChangesAsync();
    }
    catch (DbUpdateConcurrencyException)
    {
        // Handle concurrency issues
        throw;
    }
    catch (Exception ex)
    {
        // Log the exception
        throw;
    }
}

    public async Task DeleteCollection(Collection collection)
    {
        _context.Collections.Remove(collection);
        await _context.SaveChangesAsync();
    }
}
