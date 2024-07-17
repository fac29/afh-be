using afh_shared.Interfaces;
namespace afh_shared.DTOs
{
  public class CollectionDto
    {
        public int CollectionID { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public int UserID { get; set; }
        public List<MovieDto> Movies { get; set; } = new List<MovieDto>();
    }

     public class AddCollectionDto {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int UserID { get; set; }
        public List<MovieDto> CollectionMovies { get; set; } = new List<MovieDto>();
    }
}