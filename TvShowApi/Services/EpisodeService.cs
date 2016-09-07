using System;
using System.Collections.Generic;
using TvShowApi.Data;
using TvShowApi.Dtos;
using System.Data.Entity;
using System.Linq;
using TvShowApi.Models;

namespace TvShowApi.Services
{
    public class EpisodeService : IEpisodeService
    {
        public EpisodeService(IUow uow, ICacheProvider cacheProvider)
        {
            _uow = uow;
            _repository = uow.Episodes;
            _cache = cacheProvider.GetCache();
        }

        public EpisodeAddOrUpdateResponseDto AddOrUpdate(EpisodeAddOrUpdateRequestDto request)
        {
            var entity = _repository.GetAll()
                .FirstOrDefault(x => x.Id == request.Id && x.IsDeleted == false);
            if (entity == null) _repository.Add(entity = new Episode());
            entity.Name = request.Name;
            _uow.SaveChanges();
            return new EpisodeAddOrUpdateResponseDto(entity);
        }

        public dynamic Remove(int id)
        {
            var entity = _repository.GetById(id);
            entity.IsDeleted = true;
            _uow.SaveChanges();
            return id;
        }

        public ICollection<EpisodeDto> Get()
        {
            ICollection<EpisodeDto> response = new HashSet<EpisodeDto>();
            var entities = _repository.GetAll().Where(x => x.IsDeleted == false).ToList();
            foreach(var entity in entities) { response.Add(new EpisodeDto(entity)); }    
            return response;
        }


        public EpisodeDto GetById(int id)
        {
            return new EpisodeDto(_repository.GetAll().Where(x => x.Id == id && x.IsDeleted == false).FirstOrDefault());
        }

        protected readonly IUow _uow;
        protected readonly IRepository<Episode> _repository;
        protected readonly ICache _cache;
    }
}
