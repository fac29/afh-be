using System.ComponentModel.DataAnnotations.Schema;

namespace afh_be.Models 
{
    public class CollectionItem
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }
        public int CollectionID { get; set; }
        public int MovieID { get; set; }

        public Collection Collection { get; set; }
        public Movie Movie { get; set; }
    }
}