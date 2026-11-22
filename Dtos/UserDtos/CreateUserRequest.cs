using System.ComponentModel.DataAnnotations;

namespace BookKeep.Dtos;

public record CreateUserRequest(
    [Required, StringLength(50, MinimumLength = 3)] string Username,
    [Required, StringLength(256, MinimumLength = 8)] string Password
    );