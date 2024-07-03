using System.ComponentModel.DataAnnotations.Schema;

namespace afh_be.Models
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string HashedPassword { get; set; }
        public DateTime CreatedAt { get; set; }

        public ICollection<Movie> Movies { get; set; }
    }
}
