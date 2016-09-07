using TvShowApi.Dtos;
using System.Collections.Generic;

namespace TvShowApi.Services
{
    public interface IEpisodeService
    {
        EpisodeAddOrUpdateResponseDto AddOrUpdate(EpisodeAddOrUpdateRequestDto request);
        ICollection<EpisodeDto> Get();
        EpisodeDto GetById(int id);
        dynamic Remove(int id);
    }
}
