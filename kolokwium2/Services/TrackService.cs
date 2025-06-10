using kolokwium2.Data;
using kolokwium2.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace kolokwium2.Services;

public class TrackService : ITrackService
{
    private readonly DatabaseContext _context;

    public TrackService(DatabaseContext context)
    {
        _context = context;
    }
    
    public async Task AddTrack(AddNewRacerTrack addNewRacerTrack)
    {
        
    }
}