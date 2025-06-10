using kolokwium2.Models;
using kolokwium2.Models.DTOs;
using kolokwium2.Services;
using Microsoft.AspNetCore.Mvc;

namespace kolokwium2.Controllers;

[ApiController]
[Route("api/track-races")]
public class TrackController : ControllerBase
{
    private readonly ITrackService _trackService;
    
    public TrackController(ITrackService trackService)
    {
        _trackService = trackService;
    }

    [HttpPost("participants")]
    public async Task<IActionResult> AddTrack([FromBody] AddNewRacerTrack addNewRacerTrack)
    {
        try
        {
            await _trackService.AddTrack(addNewRacerTrack);
            return Ok("Track added");
        }
        catch (ArgumentException e)
        {
            return BadRequest($"Validation failed: {e.Message}");
        }
        catch (InvalidOperationException e)
        {
            return Conflict($"Conflict: {e.Message}");
        }
        catch (Exception e)
        {
            return StatusCode(500, $"An internal server error occurred: {e.Message}");
        }
    }
}