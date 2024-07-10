using afh_db.Models;
using Microsoft.EntityFrameworkCore;

namespace afh_db.Libraries;

public interface IUserLibrary
{
    Task<User?> GetUserById(int id);

    Task AddUser(User user);
    Task DeleteUser(User user);
    Task EditUser(User user);
}

public class UserLibrary : IUserLibrary
{
    private readonly MovieDBContext _context;

    public UserLibrary(MovieDBContext context)
    {
        _context = context;
    }

    public async Task DeleteUser(User user)
    {
        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
    }

    public async Task AddUser(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
    }

    public async Task<User?> GetUserById(int id)
    {
        var user = await _context.Users.FindAsync(id);
        return user;
    }

    public async Task EditUser(User user)
    {
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
    }
}
