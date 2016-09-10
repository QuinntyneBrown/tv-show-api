using TvShowApi.Dtos;
using System.Collections.Generic;

namespace TvShowApi.Services
{
    public interface ITvShowService
    {
        TvShowAddOrUpdateResponseDto AddOrUpdate(TvShowAddOrUpdateRequestDto request);
        ICollection<TvShowDto> Get();
        TvShowDto GetById(int id);
        dynamic Remove(int id);
    }
}
