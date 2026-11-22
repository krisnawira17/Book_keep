using BookKeep.Database;
using BookKeep.Dtos;
using BookKeep.Dtos.AuthDtos;
using BookKeep.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BookKeep.Services;

public class AuthService: IAuthService
{
    private readonly AppDbContext _dbContext;
    private readonly IPasswordHasher<User> _hasher;
    public AuthService(AppDbContext dbContext, IPasswordHasher<User> hasher)
    {
        _dbContext = dbContext;
        _hasher = hasher;
    }

    public async Task<AuthResult> LoginAsync(LoginRequest request, CancellationToken cancellationToken = default)
    {
        var user = await _dbContext.Users.FirstOrDefaultAsync(user => user.Username == request.Username.Trim(), cancellationToken);
        if (user is null)
        {
            return AuthResult.Fail("Invalid Credentials");
        }
        
        var verify =  _hasher.VerifyHashedPassword(user, user.PasswordHash, request.Password);
        if (verify.Equals(PasswordVerificationResult.Failed))
        {
            return AuthResult.Fail("Invalid Credentials");
        }

        if (verify.Equals(PasswordVerificationResult.SuccessRehashNeeded))
        {
            user.PasswordHash = _hasher.HashPassword(user, request.Password);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        return AuthResult.Ok(new UserDto(user.Id, user.Username));

    }
    
}