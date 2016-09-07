namespace TvShowApi.Dtos
{
    public class EpisodeAddOrUpdateResponseDto: EpisodeDto
    {
        public EpisodeAddOrUpdateResponseDto(TvShowApi.Models.Episode entity)
            :base(entity)
        {

        }
    }
}
