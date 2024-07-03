using System.ComponentModel.DataAnnotations.Schema;

namespace afh_be.Models
{
    /* public class Follower
    {
        public int ID { get; set; }
        [ForeignKey UserID]
        public int FollowerID { get; set; }
        [ForeignKey UserID]
        public int FollowedID { get; set; }

        public User User { get; set; }
    } */

    public class Follower
    {
        public int ID { get; set; }
        public int FollowerID { get; set; }
        public int FollowedID { get; set; }
        // many-to-one relationship with User
        public User User { get; set; }
    }
}