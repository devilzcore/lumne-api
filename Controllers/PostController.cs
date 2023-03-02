using dotnet_angular_blog.Context;
using dotnet_angular_blog.Model;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_angular_blog.Controllers
{
  [Route("api/[controller]")]
  public class PostController : Controller
  {
    private readonly BlogContext _context;
    public PostController(BlogContext context)
    {
      _context = context;
    }

    public IEnumerable<Post> GetAllPosts()
    {
      return _context.Posts.ToList();
    }

    [HttpGet("{id}")]
    public Post GetById(int id)
    {
      return _context.Posts.FirstOrDefault(x => x.Id == id);
    }

    [HttpPost]
    public IActionResult Create([FromBody] Post content)
    {
      _context.Posts.Add(content);
      _context.SaveChanges();
      return StatusCode(201, content);
    }
  }
}