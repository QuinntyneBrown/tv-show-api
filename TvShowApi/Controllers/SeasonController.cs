using TvShowApi.Dtos;
using TvShowApi.Services;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace TvShowApi.Controllers
{
    [Authorize]
    [RoutePrefix("api/season")]
    public class SeasonController : ApiController
    {
        public SeasonController(ISeasonService seasonService)
        {
            _seasonService = seasonService;
        }

        [Route("add")]
        [HttpPost]
        [ResponseType(typeof(SeasonAddOrUpdateResponseDto))]
        public IHttpActionResult Add(SeasonAddOrUpdateRequestDto dto) { return Ok(_seasonService.AddOrUpdate(dto)); }

        [Route("update")]
        [HttpPut]
        [ResponseType(typeof(SeasonAddOrUpdateResponseDto))]
        public IHttpActionResult Update(SeasonAddOrUpdateRequestDto dto) { return Ok(_seasonService.AddOrUpdate(dto)); }

        [Route("get")]
        [AllowAnonymous]
        [HttpGet]
        [ResponseType(typeof(ICollection<SeasonDto>))]
        public IHttpActionResult Get() { return Ok(_seasonService.Get()); }

        [Route("getById")]
        [HttpGet]
        [ResponseType(typeof(SeasonDto))]
        public IHttpActionResult GetById(int id) { return Ok(_seasonService.GetById(id)); }

        [Route("remove")]
        [HttpDelete]
        [ResponseType(typeof(int))]
        public IHttpActionResult Remove(int id) { return Ok(_seasonService.Remove(id)); }

        protected readonly ISeasonService _seasonService;


    }
}
