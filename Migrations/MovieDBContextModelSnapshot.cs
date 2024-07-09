﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using afh_be.Data;

#nullable disable

namespace afh_be.Migrations
{
    [DbContext(typeof(MovieDBContext))]
    partial class MovieDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.6");

            modelBuilder.Entity("afh_be.Models.Movie", b =>
                {
                    b.Property<int>("MovieID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Genre")
                        .HasColumnType("TEXT");

                    b.Property<string>("Image")
                        .HasColumnType("TEXT");

                    b.Property<string>("Length")
                        .HasColumnType("TEXT");

                    b.Property<int>("Rating")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("MovieID");

                    b.ToTable("Movies");

                    b.HasData(
                        new
                        {
                            MovieID = 1,
                            CreatedAt = new DateTime(2024, 6, 18, 16, 14, 58, 526, DateTimeKind.Local).AddTicks(5020),
                            Description = "A thief who steals corporate secrets through the use of dream-sharing technology is given the inverse task of planting an idea into the mind of a C.E.O.",
                            Genre = "Sci-Fi",
                            Image = "inception.jpg",
                            Length = "2h 28min",
                            Rating = 9,
                            Title = "Inception"
                        },
                        new
                        {
                            MovieID = 2,
                            CreatedAt = new DateTime(2024, 6, 23, 16, 14, 58, 526, DateTimeKind.Local).AddTicks(5020),
                            Description = "Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency.",
                            Genre = "Drama",
                            Image = "shawshank.jpg",
                            Length = "2h 22min",
                            Rating = 10,
                            Title = "The Shawshank Redemption"
                        },
                        new
                        {
                            MovieID = 3,
                            CreatedAt = new DateTime(2024, 6, 28, 16, 14, 58, 526, DateTimeKind.Local).AddTicks(5030),
                            Description = "The lives of two mob hitmen, a boxer, a gangster and his wife, and a pair of diner bandits intertwine in four tales of violence and redemption.",
                            Genre = "Crime",
                            Image = "pulpfiction.jpg",
                            Length = "2h 34min",
                            Rating = 8,
                            Title = "Pulp Fiction"
                        });
                });

            modelBuilder.Entity("afh_be.Models.User", b =>
                {
                    b.Property<int>("UserID")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("HashedPassword")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("UserID");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserID = 1,
                            CreatedAt = new DateTime(2024, 6, 8, 16, 14, 58, 526, DateTimeKind.Local).AddTicks(4860),
                            Email = "john@example.com",
                            HashedPassword = "hashed_password_1",
                            Name = "John Doe"
                        },
                        new
                        {
                            UserID = 2,
                            CreatedAt = new DateTime(2024, 6, 13, 16, 14, 58, 526, DateTimeKind.Local).AddTicks(4920),
                            Email = "jane@example.com",
                            HashedPassword = "hashed_password_2",
                            Name = "Jane Smith"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
