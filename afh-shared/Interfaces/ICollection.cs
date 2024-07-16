namespace afh_shared.Interfaces
{
    public interface ICollection
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public int UserID { get; set; }
        public IUser? User { get; set; }
        public ICollection<ICollectionMovie>? CollectionMovies { get; set; }
    }
}