using dotnet_angular_blog.Context;
using dotnet_angular_blog.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace dotnet_angular_blog.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class UserController : Controller
  {
    private readonly BlogContext _context;

    public UserController(BlogContext context)
    {
      _context = context;
    }
  }
}