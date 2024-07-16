using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace afh_db.Models
{
    public class Collection
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CollectionID { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public int UserID { get; set; }
        // public User? User { get; set; }
        public ICollection<CollectionMovie> CollectionMovies { get; set; } = new List<CollectionMovie>();
    }
}