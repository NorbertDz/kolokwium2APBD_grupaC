namespace kolokwium2.Models.DTOs;

public class AddNewRacerTrack
{
    public string RaceName { get; set; }
    public string TrackName { get; set; }
    public List<ParticipationsDto> Participations { get; set; }
}

public class ParticipationsDto
{
    public int RacerId { get; set; }
    public int Position { get; set; }
    public int FinishTimeInSeconds { get; set; }
}