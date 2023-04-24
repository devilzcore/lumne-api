using lumne_api.Model;
using lumne_api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace lumne_api.Context
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
      base.OnModelCreating(modelBuilder);
    }
  }
}