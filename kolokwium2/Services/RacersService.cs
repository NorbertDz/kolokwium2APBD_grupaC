using kolokwium2.Data;
using kolokwium2.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace kolokwium2.Services;

public class RacersService : IRacersService
{
    private readonly DatabaseContext _context;

    public RacersService(DatabaseContext context)
    {
        _context = context;
    }
    
    public async Task<GetRacersParticipationsDTO> GetRacersParticipations(int Id)
    {
        var racer = await _context.Racers
            .Where(c => c.RacerId == Id)
            .Select(e => new GetRacersParticipationsDTO
            {
                FirstName = e.FirstName,
                LastName = e.LastName,
                Participations = e.RaceParticipations.Select(p => new ParticipationsDTO()
                {
                    Race = new RaceDTO()
                    {
                        Name = p.TrackRace.Race.Name,
                        Location = p.TrackRace.Race.Location,
                        Date = p.TrackRace.Race.Date
                    },
                    Track = new TrackDTO()
                    {
                        Name = p.TrackRace.Track.Name,
                        LengthInKm = p.TrackRace.Track.LengthInKm,
                    },
                    Laps = p.TrackRace.Laps,
                    FinishInTimeInSeconds = p.FinishTimeInSeconds,
                    Position = p.Position

                }).ToList()
            }).FirstOrDefaultAsync();
        
        if (racer == null)
            throw new Exception("Racer not found");
        
        return racer;
    }
}