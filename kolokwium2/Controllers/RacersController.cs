using kolokwium2.Services;
using Microsoft.AspNetCore.Mvc;

namespace kolokwium2.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RacersController : ControllerBase
{
    private readonly IRacersService _racersService;
    
    public RacersController(IRacersService racersService)
    {
        _racersService = racersService;
    }
    
    [HttpGet("{id}/participations")]
    public async Task<IActionResult> GetRacersParticipations(int id)
    {
        var racer = await _racersService.GetRacersParticipations(id);
        return Ok(racer);
    }
}