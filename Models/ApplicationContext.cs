using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace TestTaskLasmart.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Point> Points { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public ApplicationContext(DbContextOptions options) : base(options) 
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Point>().HasData(
                new Point
                {
                    PointID = 1,
                    X = 150,
                    Y = 40,
                    R = 10,
                    Color = "LightGrey"
                },
                new Point
                {
                    PointID = 2,
                    X = 450,
                    Y = 40,
                    R = 40,
                    Color = "Red"
                },
                new Point
                {
                    PointID = 3,
                    X = 700,
                    Y = 200,
                    R = 10,
                    Color = "Pink"
                },
                new Point
                {
                    PointID = 4,
                    X = 550,
                    Y = 230,
                    R = 20,
                    Color = "Blue"
                }
            );
            modelBuilder.Entity<Comment>().HasData(
                new Comment
                {
                    CommentID = 1,
                    CommentText = "comment 1",
                    BackgroundColor = "White",
                    PointID = 1
                },
                new Comment
                {
                    CommentID = 2,
                    CommentText = "comment 2",
                    BackgroundColor = "Yellow",
                    PointID = 1
                },
                new Comment
                {
                    CommentID = 3,
                    CommentText = "comment 3",
                    BackgroundColor = "White",
                    PointID = 2
                },
                new Comment
                {
                    CommentID = 4,
                    CommentText = "comment 4",
                    BackgroundColor = "Grey",
                    PointID = 2
                },
                new Comment
                {
                    CommentID = 5,
                    CommentText = "comment 5",
                    BackgroundColor = "White",
                    PointID = 2
                },
                new Comment
                {
                    CommentID = 6,
                    CommentText = "comment 6 looooooooooooong comment",
                    BackgroundColor = "Yellow",
                    PointID = 2
                },
                new Comment
                {
                    CommentID = 7,
                    CommentText = "comment 7",
                    BackgroundColor = "Grey",
                    PointID = 2
                },
                new Comment
                {
                    CommentID = 8,
                    CommentText = "comment 8",
                    BackgroundColor = "White",
                    PointID = 2
                },
                new Comment
                {
                    CommentID = 9,
                    CommentText = "comment 9",
                    BackgroundColor = "LightBlue",
                    PointID = 3
                },
                new Comment
                {
                    CommentID = 10,
                    CommentText = "comment 100000002",
                    BackgroundColor = "Transparent",
                    PointID = 3
                },
                new Comment
                {
                    CommentID = 11,
                    CommentText = "no comment",
                    BackgroundColor = "DarkGreen",
                    PointID = 4
                }
            );
        }
    }
}
