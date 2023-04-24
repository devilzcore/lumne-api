using lumne_api.Model;
using lumne_api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace lumne_api.Context
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