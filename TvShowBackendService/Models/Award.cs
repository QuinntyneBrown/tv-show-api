using System.ComponentModel.DataAnnotations.Schema;

namespace TvShowApi.Models
{
    public class Award
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
    }
}
