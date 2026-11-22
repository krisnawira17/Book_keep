using System.ComponentModel.DataAnnotations;

namespace BookKeep.Dtos;

public record ChangePasswordRequest([Required] string OldPassword, [Required] string NewPassword);