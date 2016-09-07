using System.ComponentModel.DataAnnotations.Schema;

namespace TvShowApi.Models
{
    public class SeasonDigitalAsset
    {
        public int Id { get; set; }
        [ForeignKey("Season")]
        public int? SeasonId { get; set; }
        public Season Season { get; set; }
        [ForeignKey("DigitalAsset")]
        public int? DigitalAssetId { get; set; }
        public DigitalAsset DigitalAsset { get; set; }
    }
}
