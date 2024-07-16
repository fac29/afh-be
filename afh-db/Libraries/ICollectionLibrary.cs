// using System.Data.Common;
// using System.Text.Json;
using afh_db.Models;
using Microsoft.EntityFrameworkCore;

namespace afh_db.Libraries;

public interface ICollectionLibrary
{
    Task<List<Collection>> GetCollectionsList();
    Task<Collection?> GetCollectionById(int id);
    Task AddCollection(Collection collection);
    Task EditCollection(Collection collection, Collection existingCollection);
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

    public async Task EditCollection(Collection collection, Collection existingCollection)
    {
        var properties = collection.GetType().GetProperties();
        // Console.WriteLine($"Properties: {properties}");
        foreach (var property in properties)
        {
            var value = property.GetValue(collection);
            Console.WriteLine($"{property.Name} {value}");
            if (value != null)
            {
                _context.Entry(existingCollection).Property(property.Name).CurrentValue = value;
            }
        }
        // _context.Collections.Entry(existingCollection).CurrentValues.SetValues(collection);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteCollection(Collection collection)
    {
        _context.Collections.Remove(collection);
        await _context.SaveChangesAsync();
    }
}
