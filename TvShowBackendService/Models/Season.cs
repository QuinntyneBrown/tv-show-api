
using System.Collections.Generic;

namespace TvShowApi.Models
{
    public class Season
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public ICollection<SeasonDigitalAsset> SeasonDigitalAssets { get; set; } = new HashSet<SeasonDigitalAsset>();
        public ICollection<Episode> Episodes { get; set; } = new HashSet<Episode>();
    }

}
