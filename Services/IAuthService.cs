using BookKeep.Dtos.AuthDtos;

namespace BookKeep.Services;

public interface IAuthService
{
    Task<AuthResult> LoginAsync(LoginRequest request,CancellationToken cancellationToken = default);
}