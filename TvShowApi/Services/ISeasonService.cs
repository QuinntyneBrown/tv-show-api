using TvShowApi.Dtos;
using System.Collections.Generic;

namespace TvShowApi.Services
{
    public interface ISeasonService
    {
        SeasonAddOrUpdateResponseDto AddOrUpdate(SeasonAddOrUpdateRequestDto request);
        ICollection<SeasonDto> Get();
        SeasonDto GetById(int id);
        dynamic Remove(int id);
    }
}
