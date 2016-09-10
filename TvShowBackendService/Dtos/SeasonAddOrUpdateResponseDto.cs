namespace TvShowApi.Dtos
{
    public class SeasonAddOrUpdateResponseDto: SeasonDto
    {
        public SeasonAddOrUpdateResponseDto(TvShowApi.Models.Season entity)
            :base(entity)
        {

        }
    }
}
