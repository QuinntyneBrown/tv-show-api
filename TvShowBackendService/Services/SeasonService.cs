using System;
using System.Collections.Generic;
using TvShowApi.Data;
using TvShowApi.Dtos;
using System.Data.Entity;
using System.Linq;
using TvShowApi.Models;

namespace TvShowApi.Services
{
    public class SeasonService : ISeasonService
    {
        public SeasonService(IUow uow, ICacheProvider cacheProvider)
        {
            _uow = uow;
            _repository = uow.Seasons;
            _cache = cacheProvider.GetCache();
        }

        public SeasonAddOrUpdateResponseDto AddOrUpdate(SeasonAddOrUpdateRequestDto request)
        {
            var entity = _repository.GetAll()
                .FirstOrDefault(x => x.Id == request.Id && x.IsDeleted == false);
            if (entity == null) _repository.Add(entity = new Season());
            entity.Name = request.Name;
            _uow.SaveChanges();
            return new SeasonAddOrUpdateResponseDto(entity);
        }

        public dynamic Remove(int id)
        {
            var entity = _repository.GetById(id);
            entity.IsDeleted = true;
            _uow.SaveChanges();
            return id;
        }

        public ICollection<SeasonDto> Get()
        {
            ICollection<SeasonDto> response = new HashSet<SeasonDto>();
            var entities = _repository.GetAll().Where(x => x.IsDeleted == false).ToList();
            foreach(var entity in entities) { response.Add(new SeasonDto(entity)); }    
            return response;
        }


        public SeasonDto GetById(int id)
        {
            return new SeasonDto(_repository.GetAll().Where(x => x.Id == id && x.IsDeleted == false).FirstOrDefault());
        }

        protected readonly IUow _uow;
        protected readonly IRepository<Season> _repository;
        protected readonly ICache _cache;
    }
}
