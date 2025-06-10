using kolokwium2.Data;
using kolokwium2.Models;
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
        if (addNewRacerTrack.TrackName != _context.Tracks.Select(e => e.Name).FirstOrDefault())
        {
            throw new Exception("nie istnieje tor o podanej nazwie");
        }

        if (addNewRacerTrack.RaceName != _context.Races.Select(e => e.Name).FirstOrDefault())
        {
            throw new Exception("nie istnieje wyscig o podanej nazwie");
        }

        if (addNewRacerTrack.Participations.Select(e => e.RacerId).ToList() !=
            _context.Racers.Select(e => e.RacerId).ToList())
        {
            throw new Exception("Podany zawodnik nie istnieje w bazie");
        }
        
        await using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            var race = _context.Races.FirstOrDefault(r => r.Name == addNewRacerTrack.RaceName);
            var track = _context.Tracks.FirstOrDefault(t => t.Name == addNewRacerTrack.TrackName);

            if (race == null || track == null)
            {
                throw new Exception("Race or track not found in the database");
            }

            var trackRace = new TrackRace
            {
                TrackId = track.TrackId,
                RaceId = race.RaceId,
                Laps = addNewRacerTrack.Participations.Count,
                BestTimeInSeconds = addNewRacerTrack.Participations.Min(p => p.FinishTimeInSeconds)
            };

            _context.TrackRaces.Add(trackRace);
            await _context.SaveChangesAsync();
        }catch(Exception)
        {
            await transaction.RollbackAsync();
            throw;
        }
    }
}