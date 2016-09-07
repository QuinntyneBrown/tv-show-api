using System.ComponentModel.DataAnnotations.Schema;

namespace TvShowApi.Models
{
    public class EpisodeDigitalAsset
    {
        public int Id { get; set; }
        public int? EpisodeId { get; set; }
        public Episode Episode { get; set; }
        [ForeignKey("DigitalAsset")]
        public int? DigitalAssetId { get; set; }
        public DigitalAsset DigitalAsset { get; set; }
    }
}
