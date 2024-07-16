using afh_db.Models;
using afh_shared.DTOs;
using Microsoft.EntityFrameworkCore;

namespace afh_db.Libraries;

public interface IUserLibrary
{
    Task<User?> GetUserById(int id);

    Task AddUser(User user);
    Task DeleteUser(User user);
    Task EditUser(EditUserDto user, User existingUser);
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

    public async Task EditUser(EditUserDto editUser, User existingUser)
    {
       foreach (var property in editUser.GetType().GetProperties())
        {
            var value = property.GetValue(editUser);
            if (value != null)
            {
                _context.Entry(existingUser).Property(property.Name).CurrentValue = value;
            }
        }
        await _context.SaveChangesAsync();
    }
}
