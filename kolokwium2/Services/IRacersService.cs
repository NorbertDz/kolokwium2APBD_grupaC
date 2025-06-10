using kolokwium2.Models.DTOs;

namespace kolokwium2.Services;

public interface IRacersService
{
    Task<GetRacersParticipationsDTO> GetRacersParticipations(int Id);
}