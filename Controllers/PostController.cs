using System.Security.Claims;
using dotnet_angular_blog.Context;
using dotnet_angular_blog.Model;
using dotnet_angular_blog.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace dotnet_angular_blog.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class PostController : Controller
  {
    private readonly BlogContext _context;

    public PostController(BlogContext context)
    {
      _context = context;
    }

    [HttpGet]
    public IEnumerable<Post> GetAllPosts()
    {
      return _context.Posts.ToList();
    }

    [HttpGet("{id}")]
    public ActionResult GetById(int id)
    {
      var post = _context.Posts
      .Include(p => p.Categories)
      .FirstOrDefault(x => x.Id == id);

      return Ok(post);
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
      // Create an empty categories list.
      var categories = new List<Category>();

      // Loop through each category of the post.
      foreach (var categoryDto in post.Categories)
      {
        // Check if the category already exists in the database context or not.
        var category = await _context.Categories
          .FirstOrDefaultAsync(c => c.Name == categoryDto.Name);

        // If null, create a new Category and add it to the database context.
        if (category == null)
        {
          category = new Category { Name = categoryDto.Name };
          _context.Categories.Add(category);
        }

        // Add the new/updated category to our list.
        categories.Add(category);
      }

      // Update the Post object's Categories property to contain the added categories.
      post.Categories = categories;

      // author
      // var userName = User.Identity.Name;
      // var user = await _userManager.FindByNameAsync(userName);
      // var userProfileId = user.ProfileId;

      // post.Author = user.Id;

      // Add the post to the database context and save changes to the database.
      _context.Posts.Add(post);
      await _context.SaveChangesAsync();

      // Return a HTTP CreatedAtAction response with the new Post object included, along with its Id.
      return CreatedAtAction("GetById", new { id = post.Id }, post);
    }

    [Authorize(Roles = UserRoles.Admin)]
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePost([FromBody] Post post, int id)
    {
      // var postDto = _context.Posts.Find(id);
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
      // postDto.Author = post.Author;

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