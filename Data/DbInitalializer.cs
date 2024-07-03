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
            if (context.Users.Any() || context.Movies.Any() || context.Collections.Any() || context.Favourites.Any() || context.Followers.Any())
            {
                return; // DB has been seeded
            }

            // Seed Users
            var users = new User[]
            {
                new User
                {
                    ID = 1,
                    Username = "johndoe",
                    Email = "john@example.com",
                    HashedPassword = "hashed_password_1",
                    CreatedAt = DateTime.Now.AddDays(-30)
                },
                new User
                {
                    ID = 2,
                    Username = "janesmith",
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
                    ID = 1,
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
                    ID = 2,
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
                    ID = 3,
                    Title = "Pulp Fiction",
                    Length = "2h 34min",
                    Description =
                        "The lives of two mob hitmen, a boxer, a gangster and his wife, and a pair of diner bandits intertwine in four tales of violence and redemption.",
                    Genre = "Crime",
                    Image = "pulpfiction.jpg",
                    Rating = 8,
                    CreatedAt = DateTime.Now.AddDays(-10),
                }
            };

            context.Movies.AddRange(movies);
            context.SaveChanges();

            // Seed Collections
            var collections = new Collection[]
            {
                new Collection
                {
                    ID = 1,
                    Name = "Top Action Movies",
                    Description = "The best action movies of all time",
                    CreatedAt = DateTime.Now.AddDays(-5),
                    UserID = 1,
                },
                new Collection
                {
                    ID = 2,
                    Name = "Critically-Acclaimed Movies",
                    Description = "A list of movies that are critically-acclaimed",
                    CreatedAt = DateTime.Now.AddDays(-10),
                    UserID = 2,
                }
            };

            context.Collections.AddRange(collections);
            context.SaveChanges();

            // Seed Favourites
            var favourites = new Favourite[]
            {
                new Favourite
                {
                    ID = 1,
                    UserID = 1,
                    MovieID = 1,
                    CreatedAt = DateTime.Now.AddDays(-15),
                },
                new Favourite
                {
                    ID = 2,
                    UserID = 2,
                    MovieID = 3,
                    CreatedAt = DateTime.Now.AddDays(-5),
                }
            };

            context.Favourites.AddRange(favourites);
            context.SaveChanges();

            // Seed Followers
            // var followers = new Follower[]
            // {
            //     new Follower
            //     {
            //         ID = 1,
            //         FollowerID = 1,
            //         FollowedID = 2,
            //     },
            //     new Follower
            //     {
            //         ID = 2,
            //         FollowerID = 2,
            //         FollowedID = 1,
            //     }
            // };

            // context.Followers.AddRange(followers);
            // context.SaveChanges();
        }
    }
}
