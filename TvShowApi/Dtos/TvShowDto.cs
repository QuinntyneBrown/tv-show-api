namespace TvShowApi.Dtos
{
    public class TvShowDto
    {
        public TvShowDto()
        {

        }

        public TvShowDto(Models.TvShow entity)
        {
            Id = entity.Id;
            Name = entity.Name;
        }

        public int? Id { get; set; }
        public string Name { get; set; }
    }
}
