using kolokwium2.Models;
using Microsoft.EntityFrameworkCore;

namespace kolokwium2.Data;

public class DatabaseContext :DbContext
{
    public DbSet<Race> Races { get; set; }
    public DbSet<RaceParticipation> RaceParticipations  { get; set; }
    public DbSet<Racer> Racers  { get; set; }
    public DbSet<Track> Tracks  { get; set; }
    public DbSet<TrackRace> TrackRaces  { get; set; }
    
    protected DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Race>().HasData(new List<Race>()
        {
            new Race() {RaceId = 1, Name= "abcd",Location = "Puerto Rico",Date = DateTime.Now},
            new Race() {RaceId = 2, Name= "gwef",Location = "Warszawa",Date = DateTime.Now},
            new Race() {RaceId = 3, Name= "dfg",Location = "Krakow",Date = DateTime.Now}
        });
        modelBuilder.Entity<RaceParticipation>().HasData(new List<RaceParticipation>()
        {
            new RaceParticipation() {TrackRaceId = 1,RacerId = 1,FinishTimeInSeconds = 600,Position = 1},
            new RaceParticipation() {TrackRaceId = 1,RacerId = 2,FinishTimeInSeconds = 601,Position = 2},
            new RaceParticipation() {TrackRaceId = 1,RacerId = 3,FinishTimeInSeconds = 602,Position = 3},
            new RaceParticipation() {TrackRaceId = 2,RacerId = 1,FinishTimeInSeconds = 500,Position = 1},
            new RaceParticipation() {TrackRaceId = 2,RacerId = 2,FinishTimeInSeconds = 550,Position = 2},
        });
        modelBuilder.Entity<Racer>().HasData(new List<Racer>()
        {
            new Racer() {RacerId = 1,FirstName = "Jan",LastName = "Kwiatek"},   
            new Racer() {RacerId = 2,FirstName = "Witold",LastName = "Ostatni"},   
            new Racer() {RacerId = 3,FirstName = "Włodzimierz",LastName = "Kowalski"},   
        });
        modelBuilder.Entity<Track>().HasData(new List<Track>()
        {
            new Track() {TrackId = 1,Name = "tor numero uno",LengthInKm = 20},
            new Track() {TrackId = 2,Name = "ala ma kota",LengthInKm = 15.5},
            new Track() {TrackId = 3,Name = "kot ma ale",LengthInKm = 20.3},
        });
        modelBuilder.Entity<TrackRace>().HasData(new List<TrackRace>()
        {
            new TrackRace() {TrackRaceId = 1, TrackId = 1,RaceId = 1,Laps = 50,BestTimeInSeconds = 400},
            new TrackRace() {TrackRaceId = 2, TrackId = 3,RaceId = 2,Laps = 45,BestTimeInSeconds = 300},
            new TrackRace() {TrackRaceId = 3, TrackId = 2,RaceId = 3,Laps = 32,BestTimeInSeconds = 650},
            new TrackRace() {TrackRaceId = 4, TrackId = 2,RaceId = 1,Laps = 23,BestTimeInSeconds = 230},
        });
    }
}