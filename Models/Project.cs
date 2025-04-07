namespace ProjectManager.API.Models
{
    public class Project
    {
        public int Id { get; set; } // Chave primária
        public string Name { get; set; }
        public string Description { get; set; }

        // Relação: Um projeto pertence a um usuário
        public int UserId { get; set; }
        public User User { get; set; }

        // Um projeto tem várias tarefas
        public List<TaskItem> Tasks { get; set; }
    }
}
