namespace ProjectManager.API.Models
{
    public class User
    {
        public int Id { get; set; } // Chave primária
        public string Name { get; set; }
        public string Email { get; set; }

        // Relação: Um usuário pode ter vários projetos
        public List<Project> Projects { get; set; }
    }
}