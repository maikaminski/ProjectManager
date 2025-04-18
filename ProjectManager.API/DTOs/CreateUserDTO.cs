using System.ComponentModel.DataAnnotations;

namespace ProjectManager.API.DTOs;

public class CreateUserDTO
{
    [Required]
    public string Name { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;
}
