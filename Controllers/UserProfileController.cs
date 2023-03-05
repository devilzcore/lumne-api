using dotnet_angular_blog.Context;
using dotnet_angular_blog.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace dotnet_angular_blog.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class UserProfileController : Controller
  {
    private readonly BlogContext _context;

    public UserProfileController(BlogContext context)
    {
      _context = context;
    }

    [HttpGet]
    public IEnumerable<UserProfile> GetAllUsersProfile()
    {
      return _context.UserProfiles.ToList();
    }

    [HttpGet("{id}")]
    public ActionResult GetById(int id)
    {
      var profile = _context.UserProfiles
      .FirstOrDefault(p => p.Id == id);

      return Ok(profile);
    }

    // TODO: Fazer verificação se o User existe então criar um perfil para o usuário
    // TODO: Talvez seja melhor criar um perfil na criação de conta? e usar o Post como atualizar perfil se user existir.
    // [HttpPost]
    // public async Task<IActionResult> CreateProfile([FromBody] UserProfile profile)
    // {
    //   if (profile == null)
    //   {
    //     return BadRequest();
    //   }

    //   _context.UserProfiles.Add(profile);
    //   await _context.SaveChangesAsync();
    //   return CreatedAtAction("GetById", new { id = profile.Id }, profile);
    // }

    // TODO: Atualizar as informações do perfil do usuário
    // [HttpPut]
    // public async Task<IActionResult> UpdateProfile([FromBody] UserProfile profile, int id)
    // {
    //   await _context.SaveChangesAsync();
    //   return Ok(profile);
    // }

    // TODO: Não deleta o id do banco de dados, apenas inserir uma coluna com status = 0 o 1
    // [HttpDelete]
    // public ActionResult DeleteProfile(int id)
    // {
    //   return NoContent();
    // }
  }
}