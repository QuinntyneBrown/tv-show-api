using TvShowApi.Dtos;
using System.Collections.Generic;

namespace TvShowApi.Services
{
    public interface IRoleService
    {
        RoleAddOrUpdateResponseDto AddOrUpdate(RoleAddOrUpdateRequestDto request);
        ICollection<RoleDto> Get();
        RoleDto GetById(int id);
        dynamic Remove(int id);
    }
}
