using System.ComponentModel.DataAnnotations.Schema;

namespace afh_be.Models
{
    public class Collection
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public int UserID { get; set; }

        public User User { get; set; }
    }
}