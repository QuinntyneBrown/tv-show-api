namespace TvShowApi.Dtos
{
    public class SeasonDto
    {
        public SeasonDto(TvShowApi.Models.Season entity)
        {
            this.Id = entity.Id;
            this.Name = entity.Name;
        }

        public SeasonDto()
        {
            
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
