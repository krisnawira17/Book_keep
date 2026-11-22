using BookKeep.Database;
using BookKeep.Dtos;
using BookKeep.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BookKeep.Services;

public class UserService : IUserService
{
    private readonly AppDbContext _dbContext;
    private readonly IPasswordHasher<User> _hasher;

    public UserService(AppDbContext db, IPasswordHasher<User> hasher)
    {
        _dbContext = db;
        _hasher = hasher;
    }
    
    public async Task<UserDto> CreateUserAsync(
        CreateUserRequest request, CancellationToken cancellationToken = default)
    {
        var user = new User
        {
            Username = request.Username,
            PasswordHash = _hasher.HashPassword(null!, request.Password),
        };

        _dbContext.Users.Add(user);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return new UserDto(user.Id, user.Username);
    }

    public async Task<UserDto?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var user = await _dbContext.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Id == id, cancellationToken);
        return user is null ? null : new UserDto(user.Id, user.Username);
    }

    public async Task DeleteUserAsync(int id, CancellationToken cancellationToken = default)
    {
        var user = await _dbContext.Users.FindAsync(new Object[] {id}, cancellationToken);
        if (user is null) return;
        _dbContext.Users.Remove(user);
        await _dbContext.SaveChangesAsync(cancellationToken); 
    }

    public async Task UpdateUserAsync(int id, UpdateUserRequest request, CancellationToken cancellationToken = default)
    {
        var user = await _dbContext.Users.FindAsync(new Object[] {id}, cancellationToken);
        if (user is null) throw new KeyNotFoundException($"User {id} not found");;
        user.Username = request.Username.Trim();
    }
}