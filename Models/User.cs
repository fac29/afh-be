using System.ComponentModel.DataAnnotations.Schema;

namespace afh_be.Models
{
    // public class User
    // {
    //     [DatabaseGenerated(DatabaseGeneratedOption.None)]
    //     [ForeignKey ("UserID, FollowerID, FollowedID")]
    //     public int ID { get; set; }
    //     public string Username { get; set; }
    //     public string Email { get; set; }
    //     public string HashedPassword { get; set; }
    //     public DateTime CreatedAt { get; set; }
    // }

    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [ForeignKey ("UserID, FollowerID, FollowedID")]
        public int ID { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string HashedPassword { get; set; }
        public DateTime CreatedAt { get; set; }

        // one-to-many relationship with Collection
        public ICollection<Collection> Collections { get; } = new List<Collection>();
        // one-to-many relationship with Favourite
        public ICollection<Favourite> Favourites { get; } = new List<Favourite>();

    }
}
