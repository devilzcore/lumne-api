using lumne_api.Context;
using lumne_api.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace lumne_api.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CategoryController : Controller
  {
    private readonly BlogContext _context;

    public CategoryController(BlogContext context)
    {
      _context = context;
    }

    [HttpGet]
    public IEnumerable<Category> GetAllCategories()
    {
      return _context.Categories.ToList();
    }

    [HttpGet("{id}")]
    public ActionResult GetById(int id)
    {
      var category = _context.Categories
      .Include(p => p.Posts)
      .FirstOrDefault(c => c.Id == id);

      return Ok(category);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCategory([FromBody] Category category)
    {
      if (category == null)
      {
        return BadRequest();
      }

      var existingCategoryByName = _context.Categories.FirstOrDefault(c => c.Name == category.Name);
      if (existingCategoryByName != null)
      {
        return BadRequest();
      }

      _context.Categories.Add(category);
      await _context.SaveChangesAsync();

      return CreatedAtAction("GetById", new { id = category.Id }, category);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCategory([FromBody] Category category, int id)
    {
      var categoryDto = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);

      categoryDto.Name = category.Name;

      _context.Categories.Update(categoryDto);
      await _context.SaveChangesAsync();

      return Ok(categoryDto);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Category>> DeleteCategory(int id)
    {
      var category = _context.Categories.Find(id);
      if (category == null)
      {
        return NotFound();
      }

      _context.Categories.Remove(category);
      await _context.SaveChangesAsync();

      return NoContent();
    }

    private bool CategoryExists(int id)
    {
      return _context.Categories.Any(e => e.Id == id);
    }
  }
}