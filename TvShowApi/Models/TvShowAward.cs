using System.ComponentModel.DataAnnotations.Schema;

namespace TvShowApi.Models
{
    public class TvShowAward
    {
        public int Id { get; set; }
        public int? AwardId { get; set; }
        public Award Award { get; set; }
        [ForeignKey("TvShow")]
        public int? TvShowId { get; set; }
        public TvShow TvShow { get; set; }
    }
}
