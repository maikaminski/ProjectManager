namespace ProjectManager.API.DTOs;

public class ProjectCreateDTO
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int UserId { get; set; }
}
