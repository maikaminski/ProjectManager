using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ProjectManager.API.Models;

public class Project
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = string.Empty;

    [Required]
    public string Description { get; set; } = string.Empty;

    public int UserId { get; set; }

    [ForeignKey("UserId")]
    [JsonIgnore]
    public User? User { get; set; }

    [JsonIgnore]
    public List<TaskItem>? Tasks { get; set; } = new();
}

