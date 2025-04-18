using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProjectManager.API.Models;

public class TaskItem
{
    public int Id { get; set; }

    [Required]
    public string Title { get; set; } = string.Empty;

    [Required]
    public string Status { get; set; } = string.Empty;

    public int ProjectId { get; set; }

    [JsonIgnore]
    public Project? Project { get; set; }
}
