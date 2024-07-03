using afh_be.Models;
using Microsoft.EntityFrameworkCore;

namespace afh_be.Data
{
    public class MovieDBContext : DbContext
    {
        public MovieDBContext(DbContextOptions<MovieDBContext> options)
            : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Collection> Collections { get; set; }
        public DbSet<Favourite> Favourites { get; set; }
        public DbSet<Follower> Followers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>().ToTable("Movie");
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Collection>().ToTable("Collection");
            modelBuilder.Entity<Favourite>().ToTable("Favourite");
            modelBuilder.Entity<Follower>().ToTable("Follower");
        }
    }
}
