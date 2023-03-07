using dotnet_angular_blog.Models;
using Microsoft.AspNetCore.Identity;

namespace dotnet_angular_blog.Model
{
  public class UserProfile : IdentityUser
  {
    public string Avatar { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Bio { get; set; }

    public virtual ICollection<Post> Posts { get; set; }
  }
}