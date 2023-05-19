using System.Security.Claims;
using lumne_api.Context;
using lumne_api.Model;
using lumne_api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace lumne_api.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class PostController : Controller
  {
    private readonly BlogContext _context;

    public PostController(
      BlogContext context
      )
    {
      _context = context;
    }

    [HttpGet]
    public IEnumerable<Post> GetAllPosts()
    {
      return _context.Posts.Include(p => p.Categories).ToList();
    }

    [HttpGet("search/{title}")]
    public ActionResult GetById(string title)
    {
      var post = _context.Posts
      .Where(p => p.Title.Contains(title))
      .ToList();

      return Ok(post);
    }

    [HttpGet("{id}")]
    public ActionResult GetById(int id)
    {
      var post = _context.Posts
      .Include(p => p.Categories)
      .FirstOrDefault(x => x.Id == id);

      return Ok(post);
    }

    [HttpGet("page/{page}")]
    public ActionResult GetByPage(int page)
    {
      var limitPosts = 4;
      var skipPosts = (page - 1) * limitPosts;
      var posts = _context.Posts
      .Include(p => p.Categories)
      .OrderByDescending(x => x.Id)
      .Skip(skipPosts)
      .Take(limitPosts)
      .ToList();

      return Ok(posts);
    }

    [HttpGet("category/{category}")]
    public ActionResult GetByCategory(string category)
    {
      var post = _context.Posts
      .Include(p => p.Categories)
      .Where(p => p.Categories.Any(c => c.Name == category))
      .ToList();

      return Ok(post);
    }

    [Authorize(Roles = UserRoles.Admin)]
    [HttpPost]
    public async Task<IActionResult> CreatePost([FromBody] Post post)
    {
      var categories = new List<Category>();

      foreach (var categoryDto in post.Categories)
      {
        var category = await _context.Categories
          .FirstOrDefaultAsync(c => c.Name == categoryDto.Name);

        if (category == null)
        {
          category = new Category { Name = categoryDto.Name };
          _context.Categories.Add(category);
        }

        categories.Add(category);
      }

      post.Categories = categories;
      post.PostedAt = DateTime.Now;

      string author = User.Identity.Name;
      post.Author = author;

      _context.Posts.Add(post);
      await _context.SaveChangesAsync();

      return CreatedAtAction("GetById", new { id = post.Id }, post);
    }

    [Authorize(Roles = UserRoles.Admin)]
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePost([FromBody] Post post, int id)
    {
      var postDto = await _context.Posts
        .Include(p => p.Categories)
        .FirstOrDefaultAsync(p => p.Id == id);

      if (postDto == null)
      {
        return NotFound();
      }

      var categories = new List<Category>();

      foreach (var categoryDto in post.Categories)
      {
        var category = await _context.Categories
          .FirstOrDefaultAsync(c => c.Name == categoryDto.Name);

        if (category == null)
        {
          category = new Category { Name = categoryDto.Name };
          _context.Categories.Add(category);
        }

        categories.Add(category);
      }

      postDto.Title = post.Title;
      postDto.Summary = post.Summary;
      postDto.Image = post.Image;
      postDto.Content = post.Content;
      postDto.ReadingTime = post.ReadingTime;
      postDto.Categories = categories;
      postDto.EnumPostPermission = post.EnumPostPermission;

      _context.Posts.Update(postDto);
      await _context.SaveChangesAsync();

      return Ok(postDto);
    }

    [Authorize(Roles = UserRoles.Admin)]
    [HttpDelete("{id}")]
    public async Task<ActionResult<Post>> DeletePost(int id)
    {
      var post = _context.Posts.Find(id);
      if (post == null)
      {
        return NotFound();
      }

      _context.Posts.Remove(post);
      await _context.SaveChangesAsync();

      return NoContent();
    }
  }
}