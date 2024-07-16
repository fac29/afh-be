using afh_shared.Interfaces;
namespace afh_shared.DTOs
{
  public class MovieDto
    {
        public int MovieID { get; set; }
        public string? Title { get; set; }
        public string? Length { get; set; }
        public string? Description { get; set; }
        public string? Genre { get; set; }
        public string? Image { get; set; }        
        public int Rating { get; set; }
        // public ICollection<ICollectionMovie>? CollectionMovies { get; set; }
    }

    public class AddMovieDto {
       public string? Title { get; set; }
        public string? Length { get; set; }
        public string? Description { get; set; }
        public string? Genre { get; set; }
        public string? Image { get; set; }        
        public int Rating { get; set; }
    }
}