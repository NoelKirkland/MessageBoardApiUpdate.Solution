using Microsoft.EntityFrameworkCore;

namespace MessageBoard.Models
{
  public class MessageBoardContext : DbContext
  {
    public MessageBoardContext(DbContextOptions<MessageBoardContext> options) : base(options)
    {
    }
    public DbSet<User> Users { get; set; } 
    public DbSet<Board> Boards { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<Message> Messages { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<User>()
      .HasData(
        new User { Id = 1, FirstName = "Admin", LastName = "User", Username = "noel", Password = "noel", Role = Role.Admin },
        new User { Id = 2, FirstName = "Admin", LastName = "User", Username = "spencer", Password = "spencer", Role = Role.Admin },
        new User { Id = 3, FirstName = "Admin", LastName = "User", Username = "christine", Password = "christine", Role = Role.Admin }      
      );

      builder.Entity<Board>().HasData(
        new Board { BoardId = 1, Name = "Programming", Description = "General discussions about computer programming i.e., best practices, tips-and-trick, etc..."},
        new Board { BoardId = 2, Name = "Pets", Description = "A place where we can share cute things our pets have done"},
        new Board { BoardId = 3, Name = "Diet/Nutrition", Description = "Trading nutrition tips, recipes, and support"},
        new Board { BoardId = 4, Name = "Video Games", Description = "A friendly chat about what video games we are playing these days"},
        new Board { BoardId = 5, Name = "Eats!", Description = "Best places to eat around Portland"}
      );

      builder.Entity<Post>().HasData(
        new Post { PostId = 1, BoardId = 1, Title = "C#" },
        new Post { PostId = 2, BoardId = 1, Title = "JavaScript" },
        new Post { PostId = 3, BoardId = 2, Title = "Dogs" }
      );

      builder.Entity<Message>().HasData(
        new Message { MessageId = 1, PostId = 1, Heading = "C# Sucks!", Body = "JK! C# Rocks."},
        new Message { MessageId = 2, PostId = 1, Heading = "Databases, Databases, Databases", Body = "Songs to listen to while making a database?"},
        new Message { MessageId = 3, PostId = 3, Heading = "My Dog keeps eating trash?", Body = "Suggestions?"}
      );
    }
  }
}