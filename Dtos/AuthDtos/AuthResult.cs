namespace BookKeep.Dtos.AuthDtos;

public record AuthResult(
    bool Success,
    UserDto? User,
    string? Error
)
{
    public static AuthResult Ok(UserDto user) => new(true, user, null);

    public static AuthResult Fail(string error) => new(false, null, error);
}
    
