using dotnet_angular_blog.Model;
using dotnet_angular_blog.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace dotnet_angular_blog.Context
{
  public class BlogContext : DbContext
  {
    public DbSet<Post> Posts { get; set; }
    public DbSet<Category> Categories { get; set; }

    public BlogContext(DbContextOptions<BlogContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      // modelBuilder.Entity<User>()
      // .HasOne(u => u.Profile)
      // .WithOne(p => p.User)
      // .HasForeignKey<UserProfile>(p => p.UserId);

      // modelBuilder.Entity<UserProfile>()
      // .HasMany(p => p.Posts)
      // .WithOne(post => post.Author)
      // .HasForeignKey(post => post.UserProfileId);

      // modelBuilder.Entity<Post>()
      // .HasMany(post => post.Categories)
      // .WithMany(category => category.Posts);

      base.OnModelCreating(modelBuilder);

      // modelBuilder.Entity<Post>()
      //   .HasOne(p => p.Author)
      //   .WithMany(u => u.Posts)
      //   .HasForeignKey(p => p.AuthorId);

      // modelBuilder.Entity<UserProfile>().ToTable("UserProfile", "dbo");
    }
  }
}