using TvShowApi.Dtos;
using TvShowApi.Services;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace TvShowApi.Controllers
{
    [Authorize]
    [RoutePrefix("api/episode")]
    public class EpisodeController : ApiController
    {
        public EpisodeController(IEpisodeService episodeService)
        {
            _episodeService = episodeService;
        }

        [Route("add")]
        [HttpPost]
        [ResponseType(typeof(EpisodeAddOrUpdateResponseDto))]
        public IHttpActionResult Add(EpisodeAddOrUpdateRequestDto dto) { return Ok(_episodeService.AddOrUpdate(dto)); }

        [Route("update")]
        [HttpPut]
        [ResponseType(typeof(EpisodeAddOrUpdateResponseDto))]
        public IHttpActionResult Update(EpisodeAddOrUpdateRequestDto dto) { return Ok(_episodeService.AddOrUpdate(dto)); }

        [Route("get")]
        [AllowAnonymous]
        [HttpGet]
        [ResponseType(typeof(ICollection<EpisodeDto>))]
        public IHttpActionResult Get() { return Ok(_episodeService.Get()); }

        [Route("getById")]
        [HttpGet]
        [ResponseType(typeof(EpisodeDto))]
        public IHttpActionResult GetById(int id) { return Ok(_episodeService.GetById(id)); }

        [Route("remove")]
        [HttpDelete]
        [ResponseType(typeof(int))]
        public IHttpActionResult Remove(int id) { return Ok(_episodeService.Remove(id)); }

        protected readonly IEpisodeService _episodeService;


    }
}
