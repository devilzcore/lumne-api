using lumne_api.Models;

namespace lumne_api.Model
{
  public class Category
  {
    public int Id { get; set; }
    public string Name { get; set; }

    public ICollection<Post> Posts { get; set; }
  }
}