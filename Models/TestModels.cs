/* using System.ComponentModel.DataAnnotations.Schema;

namespace afh_be.Models
{
    // User.cs
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

    // Movie.cs
    public class Movie
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }
        public string Image { get; set; }
        public string Length { get; set; }
        public int Rating { get; set; }
        public DateTime CreatedAt { get; set; }
        // many-to-many relationship with Collection
        public ICollection<Collection> Collections { get; set; }
    }

    // Collection.cs
    public class Collection
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public int UserID { get; set; }

        // many-to-many relationship with Movie
        public ICollection<Movie> Movies { get; set; }
        // many-to-one relationship with User
        public User User { get; set; }
    }

    // Favourite.cs
    public class Favourite
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public int MovieID { get; set; }
        public DateTime CreatedAt { get; set; }

        // many-to-one relationship with User
        public User User { get; set; } = null!; // can't exist without User
    }

    // Follower.cs
    public class Follower
    {
        public int ID { get; set; }
        [ForeignKey ("UserID")]
        public int FollowerID { get; set; }
        [ForeignKey ("UserID")]
        public int FollowedID { get; set; }
        // many-to-one relationship with User
        public User User { get; set; }
    }
} */