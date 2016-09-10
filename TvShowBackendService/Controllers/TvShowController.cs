using TvShowApi.Dtos;
using TvShowApi.Services;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace TvShowApi.Controllers
{
    [Authorize]
    [RoutePrefix("api/tvShow")]
    public class TvShowController : ApiController
    {
        public TvShowController(ITvShowService tvShowService)
        {
            _tvShowService = tvShowService;
        }

        [Route("add")]
        [HttpPost]
        [ResponseType(typeof(TvShowAddOrUpdateResponseDto))]
        public IHttpActionResult Add(TvShowAddOrUpdateRequestDto dto) { return Ok(_tvShowService.AddOrUpdate(dto)); }

        [Route("update")]
        [HttpPut]
        [ResponseType(typeof(TvShowAddOrUpdateResponseDto))]
        public IHttpActionResult Update(TvShowAddOrUpdateRequestDto dto) { return Ok(_tvShowService.AddOrUpdate(dto)); }

        [Route("get")]
        [AllowAnonymous]
        [HttpGet]
        [ResponseType(typeof(ICollection<TvShowDto>))]
        public IHttpActionResult Get() { return Ok(_tvShowService.Get()); }

        [Route("getById")]
        [HttpGet]
        [ResponseType(typeof(TvShowDto))]
        public IHttpActionResult GetById(int id) { return Ok(_tvShowService.GetById(id)); }

        [Route("remove")]
        [HttpDelete]
        [ResponseType(typeof(int))]
        public IHttpActionResult Remove(int id) { return Ok(_tvShowService.Remove(id)); }

        protected readonly ITvShowService _tvShowService;


    }
}
