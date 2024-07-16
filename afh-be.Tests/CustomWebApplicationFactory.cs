using afh_db;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

// using MovieDBContext.Data; // Replace with your actual namespace for DbContext

public class CustomWebApplicationFactory<TProgram> : WebApplicationFactory<TProgram>
    where TProgram : class
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            var descriptor = services.SingleOrDefault(d =>
                d.ServiceType == typeof(DbContextOptions<MovieDBContext>)
            );

            if (descriptor != null)
            {
                services.Remove(descriptor);
            }

            services.AddDbContext<MovieDBContext>(options =>
            {
                options.UseInMemoryDatabase("TestingDb");
            });

            var sp = services.BuildServiceProvider();
            using (var scope = sp.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<MovieDBContext>();
                db.Database.EnsureCreated();

                // modelBuilder
                //     .Entity<User>()
                //     .HasData(
                //         new User
                //         {
                //             UserID = 1,
                //             Name = "John Doe",
                //             Email = "john@example.com",
                //             HashedPassword = "hashed_password_1",
                //             CreatedAt = DateTime.Now.AddDays(-30)
                //         },
                //         new User
                //         {
                //             UserID = 2,
                //             Name = "Jane Smith",
                //             Email = "jane@example.com",
                //             HashedPassword = "hashed_password_2",
                //             CreatedAt = DateTime.Now.AddDays(-25)
                //         }
                //     );

                // modelBuilder
                //     .Entity<Movie>()
                //     .HasData(
                //         new Movie
                //         {
                //             MovieID = 1,
                //             Title = "Inception",
                //             Length = "2h 28min",
                //             Description =
                //                 "A thief who steals corporate secrets through the use of dream-sharing technology is given the inverse task of planting an idea into the mind of a C.E.O.",
                //             Genre = "Sci-Fi",
                //             Image = "inception.jpg",
                //             Rating = 9,
                //             CreatedAt = DateTime.Now.AddDays(-20),
                //         },
                //         new Movie
                //         {
                //             MovieID = 2,
                //             Title = "The Shawshank Redemption",
                //             Length = "2h 22min",
                //             Description =
                //                 "Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency.",
                //             Genre = "Drama",
                //             Image = "shawshank.jpg",
                //             Rating = 10,
                //             CreatedAt = DateTime.Now.AddDays(-15),
                //         },
                //         new Movie
                //         {
                //             MovieID = 3,
                //             Title = "Pulp Fiction",
                //             Length = "2h 34min",
                //             Description =
                //                 "The lives of two mob hitmen, a boxer, a gangster and his wife, and a pair of diner bandits intertwine in four tales of violence and redemption.",
                //             Genre = "Crime",
                //             Image = "pulpfiction.jpg",
                //             Rating = 8,
                //             CreatedAt = DateTime.Now.AddDays(-10),
                //         }
                //     );

                // modelBuilder
                //     .Entity<Collection>()
                //     .HasData(
                //         new Collection
                //         {
                //             CollectionID = 1,
                //             Name = "Best Movies",
                //             Description = "A list of the best ever movies.",
                //             UserID = 1,
                //             CreatedAt = DateTime.Now,
                //         },
                //         new Collection
                //         {
                //             CollectionID = 2,
                //             Name = "Worst Movies",
                //             Description = "A list of the worst ever movies.",
                //             UserID = 1,
                //             CreatedAt = DateTime.Now,
                //         }
                //     );
            }
        });
    }
}
