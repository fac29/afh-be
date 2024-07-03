using System.ComponentModel.DataAnnotations.Schema;

namespace afh_be.Models
{
    public class Follower
    {
        public int ID { get; set; }
        public int FollowerID { get; set; }
        public int FollowedID { get; set; }

        public User User { get; set; }
    }
}