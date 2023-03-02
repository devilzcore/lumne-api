using dotnet_angular_blog.Models;

namespace dotnet_angular_blog.Model
{
  public class Post
  {
    public int Id { get; set; }
    public string Title { get; set; }
    public string Image { get; set; }
    public string Summary { get; set; }
    public string Content { get; set; }
    public int ReadingTime { get; set; }

    public virtual ICollection<PostCategory> PostCategories { get; set; }

    public DateTime PostedAt { get; set; }
    public EnumPostPermission EnumPostPermission { get; set; }
    public UserProfile Author { get; set; }
  }
}