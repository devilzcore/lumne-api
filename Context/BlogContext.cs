using dotnet_angular_blog.Model;
using dotnet_angular_blog.Models;
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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<PostCategory>()
      .HasKey(pc => new { pc.PostId, pc.CategoryId });

      modelBuilder.Entity<PostCategory>()
      .HasOne(pc => pc.Post)
      .WithMany(p => p.PostCategories)
      .HasForeignKey(pc => pc.PostId);

      modelBuilder.Entity<PostCategory>()
      .HasOne(pc => pc.Category)
      .WithMany(p => p.PostCategories)
      .HasForeignKey(pc => pc.CategoryId);
    }
  }
}