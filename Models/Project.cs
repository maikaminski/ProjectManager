using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
    public User? User { get; set; }  // <-- agora é anulável

    public List<TaskItem>? Tasks { get; set; }  // <-- agora é anulável
}

