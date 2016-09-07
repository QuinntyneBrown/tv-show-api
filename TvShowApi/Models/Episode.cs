using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TvShowApi.Models
{
    public class Episode
    {
        public int Id { get; set; }
        [ForeignKey("Season")]
        public int? SeasonId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<EpisodeDigitalAsset> EpisodeDigitalAssets { get; set; } = new HashSet<EpisodeDigitalAsset>();
        public Season Season { get; set; }
        public bool IsDeleted { get; set; }
    }
}
