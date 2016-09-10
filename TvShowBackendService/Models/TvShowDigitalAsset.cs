using System.ComponentModel.DataAnnotations.Schema;

namespace TvShowApi.Models
{
    public class TvShowDigitalAsset
    {
        public int Id { get; set; }
        public int? TvShowId { get; set; }
        public TvShow TvShow { get; set; }
        [ForeignKey("DigitalAsset")]
        public int? DigitalAssetId { get; set; }
        public DigitalAsset DigitalAsset { get; set; }
    }
}
