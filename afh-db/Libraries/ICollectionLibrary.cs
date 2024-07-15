using afh_db.Models;
using Microsoft.EntityFrameworkCore;

namespace afh_db.Libraries;

public interface ICollectionLibrary
{
    Task<List<Collection>> GetCollectionsList();
    Task<Collection?> GetCollectionById(int id);
    Task AddCollection(Collection collection);
    Task EditCollection(Collection collection);
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
        return await _context.Collections.ToListAsync();
    }

    public async Task<Collection?> GetCollectionById(int id)
    {
        return await _context.Collections.FindAsync(id);
    }

    public async Task AddCollection(Collection collection)
    {
        await _context.Collections.AddAsync(collection);
        await _context.SaveChangesAsync();
    }

    public async Task EditCollection(Collection collection)
    {
        _context.Collections.Update(collection);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteCollection(Collection collection)
    {
        _context.Collections.Remove(collection);
        await _context.SaveChangesAsync();
    }
}
