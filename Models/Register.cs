using System.ComponentModel.DataAnnotations;
using lumne_api.Model;

namespace lumne_api.Models
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
  }
}