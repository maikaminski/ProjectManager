namespace ProjectManager.API.DTOs
{
    public class TaskItemReadDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public int ProjectId { get; set; }
    }
}
