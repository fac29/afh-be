using afh_db.Models;
using Microsoft.EntityFrameworkCore;

namespace afh_db
{
    public class MovieDBContext : DbContext
    {
        public MovieDBContext(){
        }
        public MovieDBContext(DbContextOptions<MovieDBContext> options)
            : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Collection> Collections { get; set; }
        public DbSet<CollectionMovie> CollectionMovies { get; set; }

 protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=CU.db");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder
                .Entity<User>()
                .HasData(
                    new User
                    {
                        UserID = 1,
                        Name = "John Doe",
                        Email = "john@example.com",
                        HashedPassword = "hashed_password_1",
                        CreatedAt = DateTime.Now.AddDays(-30)
                    },
                    new User
                    {
                        UserID = 2,
                        Name = "Jane Smith",
                        Email = "jane@example.com",
                        HashedPassword = "hashed_password_2",
                        CreatedAt = DateTime.Now.AddDays(-25)
                    }
                );

            modelBuilder
                .Entity<Movie>()
                .HasData(
                    new Movie
                    {
                        MovieID = 1,
                        Title = "Inception",
                        Length = "2h 28min",
                        Description =
                            "A thief who steals corporate secrets through the use of dream-sharing technology is given the inverse task of planting an idea into the mind of a C.E.O.",
                        Genre = "Sci-Fi",
                        Image = "inception.jpg",
                        Rating = 9,
                        CreatedAt = DateTime.Now.AddDays(-20),
                    },
                    new Movie
                    {
                        MovieID = 2,
                        Title = "The Shawshank Redemption",
                        Length = "2h 22min",
                        Description =
                            "Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency.",
                        Genre = "Drama",
                        Image = "shawshank.jpg",
                        Rating = 10,
                        CreatedAt = DateTime.Now.AddDays(-15),
                    },
                    new Movie
                    {
                        MovieID = 3,
                        Title = "Pulp Fiction",
                        Length = "2h 34min",
                        Description =
                            "The lives of two mob hitmen, a boxer, a gangster and his wife, and a pair of diner bandits intertwine in four tales of violence and redemption.",
                        Genre = "Crime",
                        Image = "pulpfiction.jpg",
                        Rating = 8,
                        CreatedAt = DateTime.Now.AddDays(-10),
                    }
                );

                modelBuilder.Entity<Collection>().HasData(
                new Collection
                {
                    CollectionID = 1,
                    Name = "Best Movies",
                    Description = "A list of the best ever movies.",
                    UserID = 1,
                    CreatedAt = DateTime.Now,
                },
                new Collection
                {
                    CollectionID = 2,
                    Name = "Worst Movies",
                    Description = "A list of the worst ever movies.",
                    UserID = 1,
                    CreatedAt = DateTime.Now,
                }
            );

            modelBuilder.Entity<CollectionMovie>()
                .HasKey(cm => new { cm.CollectionID, cm.MovieID });

            modelBuilder.Entity<CollectionMovie>()
                .HasOne(cm => cm.Collection)
                .WithMany(c => c.CollectionMovies)
                .HasForeignKey(cm => cm.CollectionID);

            modelBuilder.Entity<CollectionMovie>()
                .HasOne(cm => cm.Movie)
                .WithMany(m => m.CollectionMovies)
                .HasForeignKey(cm => cm.MovieID);

            modelBuilder.Entity<CollectionMovie>().HasData(
                new CollectionMovie { CollectionID = 1, MovieID = 1 },
                new CollectionMovie { CollectionID = 1, MovieID = 2 },
                new CollectionMovie { CollectionID = 2, MovieID = 3 }
            );
        }
    }
}
