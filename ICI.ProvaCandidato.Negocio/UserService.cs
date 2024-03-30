using AutoMapper;
using ICI.ProvaCandidato.Dados.Repository.Interfaces;
using ICI.ProvaCandidato.Negocio.Services.Interfaces;
using ICI.ProvaCandidato.Web.Models;
using ICI.ProvaCandidato.Web.Models.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ICI.ProvaCandidato.Negocio
{
    public class UserService : IUserService
    {
        private readonly IRepositoryUoW _repositoryUoW;
        private readonly IMapper _mapper;

        public UserService(IRepositoryUoW repositoryUoW,IMapper mapper)
        {
            _repositoryUoW = repositoryUoW;
            _mapper = mapper;
        }

        public async Task<UserEntity> AddUser(UserModelDto userDto)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<UserEntity>> GetAllUsers()
        {
            throw new System.NotImplementedException();
        }

        public Task<UserEntity> UpdateUser(UserModelDto userModelDto)
        {
            throw new System.NotImplementedException();
        }
    }
}