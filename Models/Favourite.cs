using System.ComponentModel.DataAnnotations.Schema;

namespace afh_be.Models
{
    public class Favourite
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public int MovieID { get; set; }
        public DateTime CreatedAt { get; set; }

        // many-to-one relationship with User
        public User User { get; set; } = null!; // can't exist without User
    }
}