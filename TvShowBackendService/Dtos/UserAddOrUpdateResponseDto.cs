namespace TvShowApi.Dtos
{
    public class UserAddOrUpdateResponseDto: UserDto
    {
        public UserAddOrUpdateResponseDto(TvShowApi.Models.User entity)
            :base(entity)
        {

        }
    }
}
