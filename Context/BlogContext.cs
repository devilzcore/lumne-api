using dotnet_angular_blog.Model;
using Microsoft.EntityFrameworkCore;

namespace dotnet_angular_blog.Context
{
  public class BlogContext : DbContext
  {
    public BlogContext(DbContextOptions<BlogContext> options) : base(options)
    {
    }

    DbSet<User> Users { get; set; }
    DbSet<UserProfile> UserProfiles { get; set; }
    DbSet<Post> Posts { get; set; }
    DbSet<Category> Categories { get; set; }
  }
}