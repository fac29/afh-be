using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace afh_be.Models
{
    public class Movie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonIgnore]
        public int MovieID { get; set; }

        public string? Title { get; set; }
        public string? Length { get; set; }
        public string? Description { get; set; }
        public string? Genre { get; set; }
        public string? Image { get; set; }
        public int Rating { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
