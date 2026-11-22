using System.ComponentModel.DataAnnotations;

namespace BookKeep.Dtos.AuthDtos;

public record LoginRequest([Required] string Username, [Required] string Password);