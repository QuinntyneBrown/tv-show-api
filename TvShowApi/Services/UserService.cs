using System;
using System.Collections.Generic;
using TvShowApi.Data;
using TvShowApi.Dtos;
using System.Data.Entity;
using System.Linq;
using TvShowApi.Models;

namespace TvShowApi.Services
{
    public class UserService : IUserService
    {
        public UserService(IUow uow, ICacheProvider cacheProvider)
        {
            _uow = uow;
            _repository = uow.Users;
            _cache = cacheProvider.GetCache();
        }

        public UserAddOrUpdateResponseDto AddOrUpdate(UserAddOrUpdateRequestDto request)
        {
            var entity = _repository.GetAll()
                .FirstOrDefault(x => x.Id == request.Id && x.IsDeleted == false);
            if (entity == null) _repository.Add(entity = new User());
            entity.Name = request.Name;
            _uow.SaveChanges();
            return new UserAddOrUpdateResponseDto(entity);
        }

        public dynamic Remove(int id)
        {
            var entity = _repository.GetById(id);
            entity.IsDeleted = true;
            _uow.SaveChanges();
            return id;
        }

        public ICollection<UserDto> Get()
        {
            ICollection<UserDto> response = new HashSet<UserDto>();
            var entities = _repository.GetAll().Where(x => x.IsDeleted == false).ToList();
            foreach(var entity in entities) { response.Add(new UserDto(entity)); }    
            return response;
        }


        public UserDto GetById(int id)
        {
            return new UserDto(_repository.GetAll().Where(x => x.Id == id && x.IsDeleted == false).FirstOrDefault());
        }

        protected readonly IUow _uow;
        protected readonly IRepository<User> _repository;
        protected readonly ICache _cache;
    }
}
