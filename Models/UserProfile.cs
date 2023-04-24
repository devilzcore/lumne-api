using lumne_api.Models;
using Microsoft.AspNetCore.Identity;

namespace lumne_api.Model
{
  public class UserProfile
  {
    public int Id { get; set; }
    public string Avatar { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Bio { get; set; }

    public string UserId { get; set; }
    public IdentityUser User { get; set; }
  }
}