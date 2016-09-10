namespace TvShowApi.Dtos
{
    public class UserDto
    {
        public UserDto(TvShowApi.Models.User entity)
        {
            this.Id = entity.Id;
            this.Name = entity.Name;
        }

        public UserDto()
        {
            
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
