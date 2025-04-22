namespace ProjectManager.API.Models
{
    public class User
    {
        public int Id { get; set; } // Primary key
        public string Name { get; set; }
        public string Email { get; set; }

        // Relation: one user can have several projects
       public List<Project>? Projects { get; set; }


    }
}