using TvShowApi.Models;

namespace TvShowApi.Data
{
    public interface IUow
    {
        IRepository<TvShow> TvShows { get; }
        IRepository<Season> Seasons { get; }
        IRepository<Episode> Episodes { get; }
        IRepository<DigitalAsset> DigitalAssets { get; }
        void SaveChanges();
    }
}
