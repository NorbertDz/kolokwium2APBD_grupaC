using kolokwium2.Models;
using kolokwium2.Models.DTOs;

namespace kolokwium2.Services;

public interface ITrackService
{
    Task AddTrack(AddNewRacerTrack addNewRacerTrack);
}