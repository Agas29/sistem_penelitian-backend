using Microsoft.AspNetCore.Mvc;
using Backend_sp.Repositories;

namespace Backend_sp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PenggunaController : ControllerBase
{
    private readonly IPenggunaRepository _repo;
    public PenggunaController(IPenggunaRepository repo) { _repo = repo; }

    [HttpGet("login")]
    public async Task<IActionResult> GetPenggunaLogin([FromQuery] string username, [FromQuery] string password)
    {
        var result = await _repo.LoginAsync(username, password);
        return result is null ? NotFound(new { message = "Username atau password salah" }) : Ok(result);
    }
}
