using dotnet_angular_blog.Models;

namespace dotnet_angular_blog.Model
{
  public class Category
  {
    public int Id { get; set; }
    public string Name { get; set; }

    public ICollection<Post> Posts { get; set; }
    // public ICollection<PostCategory> PostCategories { get; set; }
  }
}