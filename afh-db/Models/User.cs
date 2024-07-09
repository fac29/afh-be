using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace afh_db.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserID { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? HashedPassword { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
