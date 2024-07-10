using afh_db.Models;

namespace afh_db;

public interface IUserLibrary
{
    Task<User?> GetUser(int id);
    Task DeleteUser(int id);
}

public class UserLibrary : IUserLibrary
{
    private readonly MovieDBContext _context;

    public UserLibrary(MovieDBContext context)
    {
        _context = context;
    }

    public async Task DeleteUser(int id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user == null)
        {
            return;
        }
        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
    }

    public async Task<User?> GetUser(int id)
    {
        var user = await _context.Users.FindAsync(id);
        return user;
    }
}
