using System.ComponentModel.DataAnnotations;

namespace BookKeep.Models;

public class User
{
    public int Id { get; set; }
    [MaxLength(50)]
    public string Username { get; set; } = "";
    [MaxLength(256)]
    public string PasswordHash { get; set; } = "";
}