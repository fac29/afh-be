using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using afh_db.Models;
public class CollectionMovie
{
    public int CollectionID { get; set; }
    public Collection? Collection { get; set; }
    public int MovieID { get; set; }
    public Movie? Movie { get; set; }
}