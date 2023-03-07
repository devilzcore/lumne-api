using dotnet_angular_blog.Model;
using dotnet_angular_blog.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace dotnet_angular_blog.Context
{
  public class BlogContext : DbContext
  {
    public BlogContext(DbContextOptions<BlogContext> options) : base(options)
    {
    }

    // public DbSet<User> Users { get; set; }
    // public DbSet<UserProfile> UserProfiles { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      // base.OnModelCreating(modelBuilder);

      // modelBuilder.Entity<PostCategory>()
      //   .HasKey(pc => new { pc.PostId, pc.CategoryId });

      // modelBuilder.Entity<PostCategory>()
      //   .HasOne(pc => pc.Post)
      //   .WithMany(p => p.PostCategories)
      //   .HasForeignKey(pc => pc.PostId);

      // modelBuilder.Entity<PostCategory>()
      //   .HasOne(pc => pc.Category)
      //   .WithMany(p => p.PostCategories)
      //   .HasForeignKey(pc => pc.CategoryId);
    }
  }
}