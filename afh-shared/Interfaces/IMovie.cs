namespace afh_shared.Interfaces
{
    public interface IMovie
    {
     public string? Title { get; set; }
        public string? Length { get; set; }
        public string? Description { get; set; }
        public string? Genre { get; set; }
        public string? Image { get; set; }        
        public int Rating { get; set; }
        public DateTime CreatedAt { get; set; }
        public ICollection<ICollectionMovie>? CollectionMovies { get; set; }
    }
}