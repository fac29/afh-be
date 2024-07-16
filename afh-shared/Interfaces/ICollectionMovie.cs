namespace afh_shared.Interfaces
{
    public interface ICollectionMovie
    {
    public int CollectionID { get; set; }
    public ICollection? Collection { get; set; }
    public int MovieID { get; set; }
    public IMovie? Movie { get; set; }
    }
}

