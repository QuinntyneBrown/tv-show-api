namespace TvShowApi.Dtos
{
    public class EpisodeDto
    {
        public EpisodeDto(TvShowApi.Models.Episode entity)
        {
            this.Id = entity.Id;
            this.Name = entity.Name;
        }

        public EpisodeDto()
        {
            
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
