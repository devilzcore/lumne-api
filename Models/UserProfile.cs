namespace dotnet_angular_blog.Model
{
  public class UserProfile
  {
    int Id { get; set; }
    User UserId { get; set; }

    string Avatar { get; set; }
    string Name { get; set; }
    string LastName { get; set; }
    string Bio { get; set; }
  }
}