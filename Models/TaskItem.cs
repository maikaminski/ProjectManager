namespace ProjectManager.API.Models
{
    public class TaskItem
    {
        public int Id { get; set; } // Chave primária
        public string Title { get; set; }
        public string Status { get; set; }

        // Relação: A tarefa pertence a um projeto
        public int ProjectId { get; set; }
        public Project Project { get; set; }
    }
}
