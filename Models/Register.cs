using System.ComponentModel.DataAnnotations;
using dotnet_angular_blog.Model;

namespace dotnet_angular_blog.Models
{
  public class Register
  {
    [Required(ErrorMessage = "User Name is required")]
    public string Username { get; set; }

    [EmailAddress]
    [Required(ErrorMessage = "Email is required")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Password is required")]
    public string Password { get; set; }

    public virtual UserProfile Profile { get; set; }
  }
}