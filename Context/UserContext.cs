using dotnet_angular_blog.Model;
using dotnet_angular_blog.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace dotnet_angular_blog.Context
{
  public class UserContext : IdentityDbContext<IdentityUser>
  {
    public DbSet<UserProfile> UserProfiles { get; set; }

    public UserContext(DbContextOptions<UserContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      base.OnModelCreating(builder);
    }
  }
}