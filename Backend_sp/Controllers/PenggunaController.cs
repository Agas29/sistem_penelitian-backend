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


    [HttpGet("informasi")]
    public async Task<IActionResult> GetInformasiView()
    {
        try
        {
            var result = await _repo.ViewAsync();

            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Terjadi kesalahan pada server.", detail = ex.Message });
        }

    }
}