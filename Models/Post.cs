using lumne_api.Models;

namespace lumne_api.Model
{
  public class Post
  {
    public int Id { get; set; }
    public string Title { get; set; }
    public string Image { get; set; }
    public string Summary { get; set; }
    public string Content { get; set; }
    public int ReadingTime { get; set; }

    public virtual ICollection<Category> Categories { get; set; }

    public DateTime PostedAt { get; set; }
    public EnumPostPermission EnumPostPermission { get; set; }

    public string Author { get; set; }
  }
}