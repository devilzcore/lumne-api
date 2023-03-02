namespace dotnet_angular_blog.Model
{
  public class UserProfile
  {
    public int Id { get; set; }
    public User UserId { get; set; }

    public string Avatar { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Bio { get; set; }
  }
}