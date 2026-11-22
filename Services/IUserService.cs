using BookKeep.Dtos;
using BookKeep.Dtos.AuthDtos;
using BookKeep.Models;

namespace BookKeep.Services;

public interface IUserService
{
    Task<UserDto> CreateUserAsync(CreateUserRequest request, CancellationToken cancellationToken = default);
    Task<UserDto?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task DeleteUserAsync(int id, CancellationToken cancellationToken = default);
    Task UpdateUserAsync(int id, UpdateUserRequest request, CancellationToken cancellationToken = default);
}