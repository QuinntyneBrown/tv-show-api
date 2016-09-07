using System.Collections.Generic;

namespace TvShowApi.Models
{
    public class TvShow
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public ICollection<TvShowDigitalAsset> TvShowDigitalAssets { get; set; } = new HashSet<TvShowDigitalAsset>();
        public ICollection<Season> Seasons = new HashSet<Season>();
    }
}
