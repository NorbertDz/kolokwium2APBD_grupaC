using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace kolokwium2.Models;

[PrimaryKey(nameof(TrackRaceId),nameof(RacerId))]
[Table("Race_Participation")]
public class RaceParticipation
{
    [ForeignKey(nameof(TrackRace))]
    public int TrackRaceId { get; set; }
    [ForeignKey(nameof(Racer))]
    public int RacerId { get; set; }
    public int FinishTimeInSeconds { get; set; }
    public int Position { get; set; }
    
    public Racer Racer { get; set; }
    public TrackRace TrackRace { get; set; }
}