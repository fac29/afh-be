using System.ComponentModel.DataAnnotations.Schema;

namespace afh_be.Models
{
    /* public class Movie
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [ForeignKey ("MovieID")]
        public int ID { get; set; }
        public string Title { get; set; }
        public string Length { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }
        public string Image { get; set; }
        public int Rating { get; set; }
        public DateTime CreatedAt { get; set; }
    } */

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
        public ICollection<Collection> Collections { get; } = new List<Collection>();
    }
}
