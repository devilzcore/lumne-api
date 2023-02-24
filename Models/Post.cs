using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_angular_blog.Model
{
  public class Post
  {
    int Id { get; set; }
    string Title { get; set; }
    string Image { get; set; }
    string Summary { get; set; }
    string Content { get; set; }
    int ReadingTime { get; set; }
    ICollection<Category> Categories { get; set; }
    DateTime PostedAt { get; set; }
    EnumPostPermission EnumPostPermission { get; set; }
    UserProfile Author { get; set; }
  }
}