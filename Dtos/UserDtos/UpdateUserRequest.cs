using System.ComponentModel.DataAnnotations;

namespace BookKeep.Dtos;

public record UpdateUserRequest(
    [StringLength(50, MinimumLength = 3)] string? Username 
    );