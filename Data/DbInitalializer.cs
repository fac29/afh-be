using System;
using System.Linq;
using afh_be.Models;

namespace afh_be.Data
{
    public static class DbInitializer
    {
        public static void Initialize(MovieDBContext context)
        {
            // Check if the database has been seeded
            if (context.Users.Any() || context.Movies.Any())
            {
                return; // DB has been seeded
            }

            // Seed Users
            var users = new User[]
            {
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
            };

            context.Users.AddRange(users);
            context.SaveChanges();

            // Seed Movies
            var movies = new Movie[]
            {
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
                    UserID = 1
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
                    UserID = 1
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
                    UserID = 2
                }
            };

            context.Movies.AddRange(movies);
            context.SaveChanges();
        }
    }
}
