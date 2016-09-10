using System.Collections.Generic;

namespace TvShowApi.Models
{
    public class TvShow
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public int Duration { get; set; }
        public string WebsiteUrl { get; set; }

        public ICollection<TvShowDigitalAsset> TvShowDigitalAssets { get; set; } = new HashSet<TvShowDigitalAsset>();
        public ICollection<Season> Seasons { get; set; } = new HashSet<Season>();
        public ICollection<TvShowAward> TvShowAwards { get; set; } = new HashSet<TvShowAward>();
    }
}
